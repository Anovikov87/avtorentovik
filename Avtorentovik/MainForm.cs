using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Avtorentovik.Controls;
using Avtorentovik.Core.Model;
using Avtorentovik.Forms;
using Avtorentovik.Properties;
using Avtorentovik.Utils;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using System.Web;
using Newtonsoft.Json;
using Control = System.Windows.Forms.Control;
using ScrollOrientation = DevExpress.XtraEditors.ScrollOrientation;

namespace Avtorentovik
{
    public partial class MainForm : Form
    {
        public string _serverUrl = "google.ru";        
        private User _currentUser;
        private readonly LoginForm _loginForm;
        private bool showlogin;
        private bool _init;
        private bool _closing = false;
        private static long _startDate;
        private List<Order> _newOrders;
        private Dictionary<int, string> _filters;
        public MainForm(User user, LoginForm form)
        {
            _currentUser = user;
            _loginForm = form;
            InitializeComponent();            
            _newOrders =new List<Order>();
            _filters = new Dictionary<int, string> {{0, ""}, {1, ""}, {2, ""}, {3,""} };
            gridViewMain.OptionsBehavior.ReadOnly = true;
            GridLocalizer.Active = new MyGridLocalizer();
            Thread.CurrentThread.CurrentCulture=new CultureInfo("ru");
            Thread.CurrentThread.CurrentUICulture=new CultureInfo("ru");
            gridViewMain.RowCellStyle += gridViewMain_RowCellStyle;
            gridViewMain.ShownEditor += gridViewMain_ShownEditor;
            gridViewMain.CustomDrawCell += gridViewMain_CustomDrawCell;            
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            first = true;
            bw.RunWorkerAsync();
            BackgroundWorker bwcars = new BackgroundWorker();
            bwcars.DoWork += Bwcars_DoWork;
            bwcars.RunWorkerAsync();
            BackgroundWorker bwu= new BackgroundWorker();
            bwu.DoWork += Bwu_DoWork;
            bwu.RunWorkerAsync();           
            BackgroundWorker bworders= new BackgroundWorker();
            bworders.DoWork += Bworders_DoWork;
            bworders.RunWorkerAsync();
            System.Windows.Forms.Timer updatePageTimer = new System.Windows.Forms.Timer();
            updatePageTimer.Tick += UpdatePageTimer_Tick;
            updatePageTimer.Interval = 1000;
            updatePageTimer.Start();
            carPanel1.Width = panelControlDate.Width;
            System.Windows.Forms.Timer GraphTimer = new System.Windows.Forms.Timer();
            GraphTimer.Tick += GraphTimer_Tick;
            GraphTimer.Interval = 100;
            GraphTimer.Start();
        }

        private bool updateGraph;

        private void GraphTimer_Tick(object sender, EventArgs e)
        {
            if (updateGraph)
            {
                updateGraph = false;
                LoadCarGraph();
            }
        }

        private void ShowNewOrdersCount()
        {
            var orders = "";
            if (_neworderscount > 0)
            {
                orders = $" ({_neworderscount })";
            }            
            xtraTabPageOrders.Text = "Заказы"+orders;
        }

        private bool showing = false;

        private void ShowNewOrders()
        {
            showing = true;
            try
            {
                bool updategraph = false;
                for (int i = _newOrders.Count - 1; i >= 0; i--)
                {
                    SystemSounds.Asterisk.Play();
                    var order = _newOrders[i];
                    VLog.Log("Показываем заказ: " + order.SiteId);
                    AskOrderForm asf = new AskOrderForm(order);
                    if (asf.ShowDialog(this) == DialogResult.Cancel)
                    {
                        VLog.Log("Отказались от заказа");
                        order.Deleted = true;
                    }
                    else
                    {
                        VLog.Log("Подтвердили заказ");
                        updategraph = true;
                    }
                    order.Id = Model.Orders.Post(order);
                    VLog.Log(
                        string.Format(
                            "Добавляем " + (order.Deleted ? "удаленный " : "") +
                            "заказ: Машина:{0} ; Клиент: {1} ; Дата начала {2}",
                            order.Car, order.Client, order.DateFrom));
                    if (!order.Deleted) //Обновляем конкретную машину
                    {
                        lock (_allCars)
                        {
                            var car = _allCars.FirstOrDefault(q => q.SiteId == order.Car.SiteId);
                            var dcar = Model.Cars.ReadSite(order.Car.SiteId);
                            if (car != null)
                            {                              
                              car.Orders = dcar.Orders;
                            }
                            else
                            {
                                _allCars.Add(dcar);
                            }
                        }
                        _allOrders.Add(order);
                        lock (_allClients)
                        {
                            var client = new Client();
                            var dclient = new Client();
                            if (order.Client.SiteId == 0)
                            {
                                client = _allClients.FirstOrDefault(q => q.Fio == order.Client.Fio);
                                dclient = Model.Clients.ReadShortName(order.Client.Fio);
                            }
                            else
                            {
                                client = _allClients.FirstOrDefault(q => q.SiteId == order.Client.SiteId);
                                dclient = Model.Clients.ReadSite(order.Client.SiteId);
                            }
                            if (client != null)
                            {                             
                                client.Orders = dclient.Orders;
                            }
                            else
                                _allClients.Add(dclient);
                        }
                    }
                    _newOrders.Remove(order);
                }
                if (updategraph)
                {
                    if (xtraTabControl1.SelectedTabPage == xtraTabPageOrders)
                    {
                        LoadOrders();
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPageCars)
                    {
                        LoadCars();
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPageRents)
                    {
                        LoadCarGraph();
                    }
                    else if (xtraTabControl1.SelectedTabPage == xtraTabPageClients)
                    {
                        LoadCarGraph();
                    }
                }
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }
            showing = false;
        }

        private void UpdatePageTimer_Tick(object sender, EventArgs e)
        {
            if (!showing)
                ShowNewOrders();
            if (updateOrders)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPageOrders)
                {                    
                    LoadOrders();
                    updateOrders = false;
                }
                else
                    ShowNewOrdersCount();                
            }
            if (updateCars)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPageCars)
                {
                    LoadCars();
                    updateCars = false;
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPageRents)
                {
                    //LoadCarGraph();
                    updateGraph = true;
                    updateCars = false;
                }
            }
            if (updateClients)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPageClients)
                {
                    LoadClients();
                    updateClients = false;
                }
            }
        }

        private bool updateOrders;
        private bool updateCars;
        private bool updateClients;
        private bool needUpdateOrders;
        private void Bworders_DoWork(object sender, DoWorkEventArgs e)
        {
            var runtime = DateTime.Now.AddMinutes(-2);
            needUpdateOrders = false;
            while (!_closing)
            {
                if ((DateTime.Now - runtime).TotalSeconds >= 60|| needUpdateOrders)
                {                    
                    try
                    {
                        if (needUpdateOrders)
                            needUpdateOrders = false;
                        _allOrders = Model.Orders.GetAllShortbyUser(_currentUser.Id).ToList();
                        runtime = DateTime.Now;
                        updateOrders = true;
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                }
                else
                {
                    Thread.Sleep(500);
                }
            }            
        }

        private Mark[] _allMarks=new Mark[0];
        private CarModel[] _allModels=new CarModel[0];

        private void getAllcars()
        {
            lock (_allCars)
            {
                _allCars = Model.Cars.GetAllbyUser(_currentUser.Id).ToList();
            }            
            _allMarks = Model.Marks.GetAll();
            _allModels = Model.CarModels.GetAll();
        }

        private bool needUpdateCars;
        private void Bwcars_DoWork(object sender, DoWorkEventArgs e)
        {
            var runtime = DateTime.Now.AddMinutes(-2);
            needUpdateCars = false;
            while (!_closing)
            {
                if ((DateTime.Now - runtime).TotalSeconds >= 60 || needUpdateCars)
                {
                    try
                    {
                        if (needUpdateCars)
                            needUpdateCars = false;
                            getAllcars();
                        updateCars = true;
                        runtime = DateTime.Now;
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                }else
                    Thread.Sleep(500);
            }
        }

        private void Bwu_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_closing)
            {
                try
                {
                    _allClients = Model.Clients.GetAllbyUser(_currentUser.Id).ToList();
                    updateClients = true;
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                }
                Thread.Sleep(60000);
            }
        }

        private DateTime carTime;
        private DateTime orderTime;
        private DateTime clientTime;

        private List<Order> _allOrders =new List<Order>();
        private List<Client> _allClients=new List<Client>();
        private List<Car> _allCars=new List<Car>();

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_closing)
            {                
                try
                {                   
                    GetUpdates();
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                }
                finally
                {
                    Thread.Sleep(60000);
                }
            }
        }
        public void PostBron(DateTime from,DateTime to, int orderId)
        {
            string url = string.Format("https://"+ _serverUrl + "/api/company/bron?order_id={0}&bron_start_date={1}&bron_end_date={2}"
                    , orderId, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));
            PostString(url);
        }

        public void DeleteOrder(Order order)
        {
            lock (_allOrders)
            {
                var ord = _allOrders.FirstOrDefault(q => q.Id == order.Id);
                if (ord != null)
                {
                    _allOrders.Remove(ord);                    
                }                
            }
            lock (_allCars)
            {
                var car = _allCars.FirstOrDefault(q => q.Id == order.Car.Id);
                if (car != null)
                {
                    var tcar = Model.Cars.Read(car.Id);
                    car.Orders = tcar.Orders;
                }
            }
            if (order.SiteId == 0)
            {
                VLog.Log("У заказа небыло ид, поэтому не посылаем запрос на сайт");
                return ;
            }
            string url = string.Format("https://"+ _serverUrl + "/api/company/order/{0}?"
                    ,order.SiteId);
            var result = DeleteString(url);

        }
        public void PostOrder(Order order)
        {
            VLog.Log("Постим заказ");
            bool update = true;
            if (order.SiteId == 0)
            {
                VLog.Log("Создаем новый заказ");
                update = false;
            }
            var upd = update? $"/{order.SiteId}" : "";            
            
            string url = string.Format("https://"+ _serverUrl + "/api/company/order"+upd+"?catalog_id={0}&name={1}&phone=\"{2}\"&date={3}&mail=nomail&days={4}&status_id={5}&paid=1"
                    , order.Car.SiteId, order.Client.Fio, order.Client.Phone, order.DateFrom.ToString("yyyy-MM-dd HH:mm:ss"), (order.DateTo - order.DateFrom).TotalDays, order.Closed?1:0);
            //https://avtorentovik.tmweb.ru/api/company/order?catalog_id=568&name="Руслан Авдеев"&phone="+7 (915) 404-91-04"&date="14.10.2016 10:00:00"&mail=nomail&days=3&status_id=False&paid=1
            var result =PostString(url,update);
            if (!update)
            {
                var match = Regex.Match(result, "\"id\":.*?}");
                if (!string.IsNullOrEmpty(match.ToString()))
                {
                    var ind = match.ToString().Split(':')[1].Replace("}", "").TrimEnd('}').TrimEnd(',').Replace("\"","");
                    var sid = 0;
                    int.TryParse(ind, out sid);
                    if (sid > 0 && sid != order.SiteId)
                    {
                        lock (_allOrders)
                        {
                            order.SiteId = sid;
                            Model.Orders.Put(order);
                            var oldor = _allOrders.FirstOrDefault(q => q.Id == order.Id);
                            if (oldor != null)
                            {
                                oldor.SiteId = sid;
                            }
                            else
                            {
                                _allOrders.Add(order);
                            }                            
                        }
                        lock (_allCars)
                        {
                            var car = _allCars.FirstOrDefault(q => q.Id == order.Car.Id);
                            if (car != null)
                            {
                                var tcar = Model.Cars.Read(car.Id);
                                car.Orders = tcar.Orders;
                            }
                        }
                    }
                }
            }
            VLog.Log("Постим услуги к заказу");
            foreach (var service in order.Services)
            {                
               url = string.Format("https://"+ _serverUrl + "/api/company/order_company_service?order_id={0}&company_service_id={1}"
                   , order.SiteId, service.CompanyId);
                PostString(url);
            }
        }

        private HttpWebRequest formRequest(string url)
        {
            var cookies = new CookieContainer();
            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = cookies;
            request.ServicePoint.Expect100Continue = false;            
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            request.PreAuthenticate = true;
            var userName = _currentUser.Login;
            var password = _currentUser.Password;
            request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
            string credentials = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
            request.Headers[HttpRequestHeader.Authorization] = string.Format(
                "Basic {0}", credentials);
            return request;

        }
        public string DeleteString(string url)
        {            
            var request = formRequest(url);
            request.Method = "DELETE";
            VLog.Log("Удаляем строку: "+url);
            StreamReader objReader = new StreamReader(request.GetResponse().GetResponseStream());
            var response = objReader.ReadToEnd();
            var result =HttpUtility.HtmlDecode(Regex.Unescape(response));
            VLog.Log("Result:" + result);
            return result;
        }

        public void GetCarRentals()
        {
            VLog.Log("Обновляем пункты выдачи");
            var decoded = GetResponse("https://"+ _serverUrl + "/api/company/car_rental");
            dynamic dyn = JsonConvert.DeserializeObject(decoded);
            if (!((Newtonsoft.Json.Linq.JContainer)dyn).HasValues)
                return;
            /*
            {"car_rental":[{"id":59,"company_id":61,"name":"Карат авто","address":"г. Москва, Огородный проезд, д. 8",
            "coord_x":"55.8128","coord_y":"37.6042","mode":"10.00 - 19.00","night":0,"additional_description":"",
            "is_active":1,"is_deleted":0}]}
            */
            foreach (var obj in dyn.car_rental)
            {
                var currentRentals = Model.CarRentals.GetbyUser(_currentUser.Id).ToList();
                try
                {
                    if (string.IsNullOrEmpty(obj.name.ToString()))
                        return;
                    var tempR = new CarRental();
                    var deleted = false;
                    int id = 0;
                    int.TryParse(obj.id.ToString(), out id);
                    tempR.SiteId = id;
                    tempR.Name = obj.name.ToString();
                    /* id = 0;
                    int.TryParse(obj.is_deleted.ToString(), out id);
                    if (id == 1)
                        deleted = true;
                    id = -1;
                    int.TryParse(obj.is_active.ToString(), out id);
                    if (id == 0)
                        deleted = true;                                        
                        */
                    var exItem = currentRentals.FirstOrDefault(q => q.SiteId == tempR.SiteId);
                    if (exItem != null) //Обновляем данные клиента с сайта
                    {                       
                        exItem.Name = tempR.Name;
                        Model.CarRentals.Put(exItem);
                    }
                    else
                    {
                        tempR.UserId = _currentUser.Id;
                        VLog.Log("Добавляем пункт выдачи: " + tempR.Name);
                        Model.CarRentals.Post(tempR);
                        currentRentals.Add(tempR);
                    }
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                }
            }
        }

        public string PostString(string url,bool put=false)
        {
            var request = formRequest(url);
            if (put)
            {
                request.Method = @"PUT";
            }
            else
                request.Method = @"POST";            
            VLog.Log("Post-put:"+url);
            StreamReader objReader = new StreamReader(request.GetResponse().GetResponseStream());
            var response = objReader.ReadToEnd();
            var result= HttpUtility.HtmlDecode(Regex.Unescape(response));
            VLog.Log("Result:" + result);
            return result;
        }

        private string GetResponse(string url)
        {
            var request = formRequest(url);
            request.Method = "GET";      
            VLog.Log("Get: "+url);     
            StreamReader objReader = new StreamReader(request.GetResponse().GetResponseStream());
            var response = objReader.ReadToEnd();          
            VLog.Log("Result:" + response);
            return response;
        }

        private void UpdateCars()
        {
            VLog.Log("Обновляем машины");
            var decoded = GetResponse("https://"+_serverUrl+"/api/company/auto");
            dynamic dyn = JsonConvert.DeserializeObject(decoded);
            if (!((Newtonsoft.Json.Linq.JContainer)dyn).HasValues)
                return;

            //var cars = Model.Cars.GetAllbyUser(_currentUser.Id).ToList();                        
            var cRentals = Model.CarRentals.GetbyUser(_currentUser.Id).ToList();
            var marks = Model.Marks.GetAll();
            foreach (var obj in dyn.data)
            {               
                try
                {
                    var name = obj.name.ToString().Trim();
                    if (string.IsNullOrEmpty(name))
                        continue;                    
                                        
                    var tempIt = new Car();
                    var modelname = "";
                    var markid = -1;
                    var rentId = -1;
                    bool deleted = false;                                         
                        /*            
                       {"id":583,"car_rental_id":59,"name":"Duster","auto_brand_id":11,"auto_class_id":6,"auto_body_type_id":12,
                       "auto_transmission_id":1,"auto_color_id":6,"engine_power":"135","color":"","year":"2013","additional_description":""
                       ,"price_day":null,"price_bezlimit_day":0,"security_deposit":8000,"discount":"0.00","mileage_limit":200,"buyout":0,
                       "delivery":1,"is_active":1,"is_deleted":0,"created_at":"2016-02-12 22:05:15","updated_at":"2016-02-12 22:10:48",
                       "rent_prices_active":[{"id":2250,"catalog_id":583,"days_min":1,"days_max":2,"name":"","price":2300,"is_active":1,
                       "is_deleted":0,"created_at":"2016-02-12 22:05:29","updated_at":"2016-08-05 19:28:31"},
                       {"id":2251,"catalog_id":583, "days_min":3,"days_max":7,"name":"","price":2000,"is_active":1,
                       "is_deleted":0,"created_at":"2016-02-12 22:05:36","updated_at":"2016-02-12 22:05:36"},
                       {"id":2252,"catalog_id":583,"days_min":8,"days_max":14,"name":"","price":1900,"is_active":1,"is_deleted":0,
                       "created_at":"2016-02-12 22:05:42","updated_at":"2016-02-12 22:05:42"},
                       {"id":2253,"catalog_id":583,"days_min":15,"days_max":31,"name":"","price":1800,"is_active":1,"is_deleted":0,
                       "created_at":"2016-02-12 22:05:53","updated_at":"2016-02-12 22:05:53"},
                       {"id":2254,"catalog_id":583,"days_min":31,"days_max":0,"name":"","price":1700,"is_active":1,"is_deleted":0,
                       "created_at":"2016-02-12 22:06:01","updated_at":"2016-02-12 22:06:01"}]},
                    */
                    var id = 0;
                    int.TryParse(obj.id.ToString(), out id);
                    tempIt.SiteId = id;                    
                    int.TryParse(obj.auto_brand_id.ToString(), out markid);                    
                    modelname = name;
                    id = -1;
                    int.TryParse(obj.auto_body_type_id.ToString(), out id);
                    tempIt.SetSiteBody(id);
                    id = 0;
                    int.TryParse(obj.auto_transmission_id.ToString(), out id);
                    tempIt.Kpp = id == 2;
                    int.TryParse(obj.car_rental_id.ToString(), out rentId);
                    id = -1;
                    int.TryParse(obj.is_deleted.ToString(), out id);
                    if (id == 1)
                        deleted = true;
                    id = -1;
                    int.TryParse(obj.is_active.ToString(), out id);
                    if (id == 0)
                        deleted = true;
                    id = 1;
                    int.TryParse(obj.auto_color_id.ToString(), out id);
                    tempIt.Color = (CarColor)id;                       
                                                
                    var carrent = cRentals.FirstOrDefault(q => q.SiteId == rentId);
                    if (carrent == null && rentId > 0)
                    {
                        VLog.Log("Создаем прокат");
                        carrent = new CarRental();
                        carrent.SiteId = rentId;
                        carrent.UserId = _currentUser.Id;
                        carrent.Name = "Прокат #" + rentId;
                        carrent.Id = Model.CarRentals.Post(carrent);
                        cRentals.Add(carrent);
                    }
                    tempIt.CarRental = carrent;                                          
                    var mark = marks.FirstOrDefault(q => q.SiteId == markid);
                    if (mark != null)
                    {
                        var model = mark.Models.FirstOrDefault(q => q.Name.Trim() == modelname);
                        if (model == null)
                        {                            
                            model = new CarModel();
                            model.MarkId = mark.Id;
                            model.Name = modelname;
                            model.Id = Model.CarModels.Post(model);
                            mark.Models.Add(model);
                        }
                        tempIt.Model = model;
                    }
                    tempIt.User = _currentUser;

                    var exItem = Model.Cars.ReadSite(tempIt.SiteId);
                    List<Rent> carrs = new List<Rent>();
                    if (exItem != null) //Обновляем данные с сайта
                    {
                        if (deleted)
                        {
                            VLog.Log(string.Format("Удаляем машину: {0} {1}", exItem.KppName, exItem.Model));                            
                            Model.Cars.Delete(exItem.Id);                            
                            continue;
                        }
                        if (exItem.Deleted)
                        {
                            VLog.Log("Удаленная машина, данные не меняем");
                            continue;
                        }
                        VLog.Log(string.Format("Изменяем машину: {0} {1}", exItem.KppName,exItem.Model));
                        exItem.Kpp = tempIt.Kpp;
                        exItem.Model = tempIt.Model;
                        exItem.CarRental = tempIt.CarRental;
                        exItem.Color = tempIt.Color;                
                        Model.Cars.Put(exItem);
                        exItem = Model.Cars.Read(exItem.Id);
                    }
                    else
                    {
                        if (deleted)
                        {
                            continue;
                        }
                        VLog.Log(string.Format("Добавляем машину: {0} {1}", tempIt.KppName, tempIt.Model));
                        tempIt.Id = Model.Cars.Post(tempIt);                        
                    }
                    if (exItem != null)
                    {
                        carrs = exItem.Rents;
                    }                    
                    /*"rent_prices_active":[{"id":2265,"catalog_id":586,"days_min":1,"days_max":2,"name":"","price":6900,"is_active":1,"is_deleted":0,
                   "created_at":"2016-02-12 22:22:40","updated_at":"2016-02-12 22:22:40"}]                                   */
                    var days = obj.rent_prices_active;                    
                    foreach (var day in days)
                    {                                                
                        var crent = new Rent();
                        var did = 0;
                        int.TryParse(day.id.ToString(),out did);
                        crent.SiteId = did;                        
                        did = -1;
                        int.TryParse(day.days_min.ToString(), out did);
                        crent.From = did;
                        did = -1;
                        int.TryParse(day.days_max.ToString(), out did);
                        crent.To = did;
                        did = -1;
                        int.TryParse(day.price.ToString(), out did);
                        crent.Price = did;
                        did = 0;
                        int.TryParse(day.is_active.ToString(), out did);
                        crent.Status = did == 1;                      
                        crent.CarId = tempIt.Id;
                        var orent = carrs.FirstOrDefault(q => q.SiteId == crent.SiteId);
                        if (orent != null)
                        {
                            orent.From = crent.From;
                            orent.To = crent.To;
                            orent.Price = crent.Price;
                            orent.Status = crent.Status;                            
                            Model.Rents.Put(orent);
                        }
                        else
                        {
                            Model.Rents.Post(crent);
                            carrs.Add(crent);
                        }
                    }                 
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                }
            }
        }
        private void UpdateClients()
        {            
            VLog.Log("Обновляем клиентов");
            var decoded = GetResponse("https://"+ _serverUrl + "/api/company/client");                                      
            dynamic dyn = JsonConvert.DeserializeObject(decoded);    
            if (!((Newtonsoft.Json.Linq.JContainer)dyn).HasValues)          
                return;
            /*                     {"id":"688","name":"dthdf","passport_no":"dfhd","passport_date":"dfh.dfh.dfh","issued_by":"dfhdf","birth_date":"dfhd.dfh.dfh","birth_place":"","registration_place":"dfh","driver_license":"dfh","driver_license_date":"dfh.dfh.dfh","phone":"+7 (234) 523-52-35","mail":""},
                     */
            foreach (var obj in dyn.data)
            {
                if (string.IsNullOrEmpty(obj.name.ToString()))
                    continue;
                var tempCl = new Client();
                                
                DateTime date = DateTime.MinValue;
                int id = 0;
                int.TryParse(obj.id.ToString(), out id);
                tempCl.SiteId = id;
                tempCl.Fio = obj.name.ToString();
                tempCl.Passport = obj.passport_no.ToString();                
                DateTime.TryParse(obj.passport_date.ToString(), out date);
                if (date != DateTime.MinValue)
                {
                    tempCl.When = date;
                    date = DateTime.MinValue;
                }
                tempCl.Who = obj.issued_by.ToString();
                tempCl.Born = obj.birth_place.ToString();
                tempCl.Registration = obj.registration_place.ToString();
                tempCl.License = obj.driver_license.ToString();
                DateTime.TryParse(obj.driver_license_date.ToString(), out date);
                if (date != DateTime.MinValue)
                    tempCl.LicenseDate = date;
                tempCl.Phone = obj.phone.ToString();                                
                tempCl.User = _currentUser;
                var exClient = Model.Clients.ReadSite(tempCl.SiteId) ?? Model.Clients.ReadShortName(tempCl.Fio);
                if (exClient != null) //Обновляем данные клиента с сайта
                {
                    if (exClient.Deleted)
                    {
                        continue;
                    }
                    try
                    {
                        VLog.Log("Обновляем клиента: "+exClient.Fio);
                        exClient.SiteId = tempCl.SiteId;
                        exClient.Passport = tempCl.Passport;
                        exClient.When = tempCl.When;
                        exClient.Who = tempCl.Who;
                        exClient.Born = tempCl.Born;
                        exClient.Registration = tempCl.Registration;
                        exClient.License = tempCl.License;
                        exClient.LicenseDate = tempCl.LicenseDate;
                        exClient.Phone = tempCl.Phone;
                        Model.Clients.Put(exClient);
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                }
                else
                {
                    try
                    {
                        VLog.Log("Добавляем клиента: "+tempCl.Fio);
                        lock (_allClients)
                        {
                            tempCl.Id=Model.Clients.Post(tempCl);
                            _allClients.Add(tempCl);
                        }                                            
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                }
            }
        }
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }
        private void UpdateOrders(string date)
        {            
            VLog.Log("Обновляем заказы");
            var decoded = GetResponse("https://"+ _serverUrl + "/api/company/order"+date);
            /* decoded = "{"data":[{"id":2512,"catalog_id":570,"name":"\u0411\u0443\u0440\u0442\u0430\u0441\u043e\u0432 \u0412\u0430\u0441\u0438\u043b\u0438\u0439","phone":"\"\" 7 (977) 364-22-67\"\"","mail":"nomail","address":"","passport_no":"","passport_date":"","issued_by":"","birth_date":"","birth_place":"","registration_place":"","driver_license":"","driver_license_date":"","date":"2016-12-28 10:00:00","days":"3","is_read":0,"status_id":0,"paid":1,"bron_no":"","created_at":"2016-12-27 18:18:50","updated_at":"2016-12-27 18:18:50","company_services":[],"bron":{"id":2,"order_id":2512,"start_at":"2016-12-28 10:00:00","end_at":"2016-12-31 10:00:00","is_active":1,"is_deleted":0,"created_at":"2016-12-27 18:18:51","updated_at":"2016-12-27 18:18:51"}}";*/
            dynamic dyn = JsonConvert.DeserializeObject(decoded);
            if (!((Newtonsoft.Json.Linq.JContainer)dyn).HasValues)
                return;
            var currentServices = Model.Services.GetAllByUser(_currentUser.Id);                        
            foreach (var obj in dyn.data)
            {                                                
                try
                {
                    /*                    
               id":2440,"catalog_id":568,"name":"Степурин Константин","phone":"+7 (926) 133-06-04","mail":"info@apexmebel.ru","address":"",
               "passport_no":"","passport_date":"","issued_by":"",
               "birth_date":"","birth_place":"","registration_place":"",
               "driver_license":"","driver_license_date":"",
               "date":"28.09.2016","days":"1","is_read":0,"status_id":5,"paid":0,"bron_no":"",
               "created_at":"2016-09-27 20:34:16","updated_at":"2016-09-27 20:34:16"},                  
                */
                    if (obj.bron == null)
                    {
#if DEBUG
                        VLog.Log("Брони нет - пропускаем");
#endif
                        continue;
                    }
                    var tempIt = new Order();
                    var days = 0;                    
                    DateTime datefrom = DateTime.MinValue;
                    int id = 0;
                    int.TryParse(obj.id.ToString(), out id);
                    tempIt.SiteId = id;
                    id = -1;
                    int.TryParse(obj.catalog_id.ToString(), out id);
                    var car = Model.Cars.ReadSite(id);
                    if (car == null)
                    {
                        VLog.Log("Автомобиль не найден, пропускаем заказ");
                        continue;
                    }
                    tempIt.Car = car;
                    id = 0;
                    int.TryParse(obj.paid.ToString(), out id);
                    if (id == 0)
                    {
                        VLog.Log("Заказ не оплачен, пропускаем.");
                        continue;
                    }
                    var cname = obj.name.ToString().Trim();
                    if (string.IsNullOrEmpty(cname))
                        continue;
                    var client = Model.Clients.ReadShortName(cname);
                    if (client == null)
                    {                        
                        VLog.Log("Клиент не найден, создаем нового:"+cname);
                        client = new Client();
                        DateTime datec = DateTime.MinValue;
                        client.Fio = cname;
                        client.Passport = obj.passport_no.ToString();
                        DateTime.TryParse(obj.passport_date.ToString(), out datec);
                        if (datec != DateTime.MinValue)
                        {
                            client.When = datec;
                            datec = DateTime.MinValue;
                        }
                        client.Who = obj.issued_by.ToString();
                        client.Born = obj.birth_place.ToString();
                        client.Registration = obj.registration_place.ToString();
                        client.License = obj.driver_license.ToString();
                        DateTime.TryParse(obj.driver_license_date.ToString(), out datec);
                        if (datec != DateTime.MinValue)
                            client.LicenseDate = datec;
                        client.Phone = obj.phone.ToString();
                        client.User = _currentUser;
                        client.Id= Model.Clients.Post(client);
                    }
                    tempIt.Client = client;
                    DateTime.TryParse(obj.bron.start_at.ToString(), out datefrom);
                    int.TryParse(obj.days.ToString(), out days);
                                                        
                    if (tempIt.Client == null)
                        continue;
                    if (tempIt.Car == null)
                        continue;
                    tempIt.DateFrom = datefrom;
                    if (tempIt.DateFrom == DateTime.MinValue)
                        continue;
                    datefrom = DateTime.MinValue;
                    DateTime.TryParse(obj.bron.end_at.ToString(), out datefrom);
                    if (tempIt.DateFrom == DateTime.MinValue)
                        continue;
                    tempIt.DateTo = datefrom;
                    tempIt.User = _currentUser;
                    //Тут будут добавляться услуги                    
                        //company_services":[{"id":1,"companies_id":61,"auto_services_id":4,"price_type":2,"price":1,"is_active":1,
                        //                    "is_deleted":0,"created_at":"2016-10-24 19:26:54","updated_at":"2016-10-25 14:17:20","pivot":{"order_id":2468,"company_service_id":1}                    
                        var services = obj.company_services;
                        var oservices = new List<Service>();
                        foreach (var service in services)
                        {                            
                            var serv = new Service();
                            var sid = 0;
                            int.TryParse(service.id.ToString(), out sid);
                            serv.CompanyId = sid;
                            sid = -1;
                            int.TryParse(service.auto_services_id.ToString(), out sid);
                            serv.SiteId = sid;
                            sid = -1;
                            int.TryParse(service.price_type.ToString(), out sid);
                            serv.PriceType = sid;
                            sid = -1;
                            int.TryParse(service.price.ToString(), out sid);
                            serv.Price = sid;
                            sid = 0;
                            int.TryParse(service.is_active.ToString(), out sid);
                            serv.Status = sid == 1;                                        
                            var tserv = currentServices.FirstOrDefault(q => q.CompanyId == serv.CompanyId);
                            tserv.Price = serv.Price;
                            tserv.PriceType = serv.PriceType;
                            tserv.Status = serv.Status;
                            oservices.Add(tserv);
                        }
                        tempIt.Services = oservices;
                        tempIt.User = _currentUser;
                    
                    var exItem = Model.Orders.ReadSite(tempIt.SiteId);
                    if (exItem != null) //Обновляем данные с сайта
                    {
                        VLog.Log("Обновляем заказ: "+exItem.SiteId);
                            exItem.Car = tempIt.Car;
                            exItem.Client = tempIt.Client;
                            exItem.DateFrom = tempIt.DateFrom;
                            exItem.DateTo = tempIt.DateTo;
                            exItem.Services = tempIt.Services;
                            exItem.User = _currentUser;
                            Model.Orders.Put(exItem);                      
                    }
                    else
                    {
                        tempIt.Discount = 10;
                        tempIt.DiscountType = true;
                        if (!string.IsNullOrEmpty(date))
                            _newOrders.Add(tempIt);
                        else
                        {
                            _neworderscount++;
                            VLog.Log(string.Format("Добавляем заказ: Машина:{0} ; Клиент: {1} ; Дата начала {2}",
                                tempIt.Car, tempIt.Client, tempIt.DateFrom));
                            lock (_allOrders)
                            {
                                tempIt.Id = Model.Orders.Post(tempIt);                            
                                _allOrders.Add(tempIt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                }
            }
        }

        private int _neworderscount=0;

        private void UpdateAtts()
        {
            VLog.Log("Обновляем марки");
            var decoded = GetResponse("https://"+ _serverUrl + "/api/v1/attributes");
            dynamic dyn = JsonConvert.DeserializeObject(decoded);
            if (!((Newtonsoft.Json.Linq.JContainer)dyn).HasValues)
                return;
            var marks = Model.Marks.GetAll().ToList();            
            foreach (var obj in dyn.brands)
            {
                try
                {                    
                    var tempBr = new Mark();
                    tempBr.Name = obj.value.ToString();
                    if (string.IsNullOrEmpty(tempBr.Name))
                        continue;
                    var id = 0;
                    int.TryParse(obj.id.ToString(), out id);
                    tempBr.SiteId = id;                    
                    var exItem = marks.FirstOrDefault(q => q.Name == tempBr.Name);
                    if (exItem != null) //Обновляем данные клиента с сайта
                    {
                        exItem.SiteId = tempBr.SiteId;                        
                        Model.Marks.Put(exItem);
                    }
                    else
                    {
                        VLog.Log("Добавляем марку: "+tempBr.Name);
                        Model.Marks.Post(tempBr);
                        marks.Add(tempBr);
                    }
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                }                
            }
        }

        private static bool first;

        private void UpdateServices()
        {
            VLog.Log("Обновляем услуги");
            var decoded = GetResponse("https://"+ _serverUrl + "/api/company/service/get_available");
            dynamic dyn = JsonConvert.DeserializeObject(decoded);
            if (!((Newtonsoft.Json.Linq.JContainer)dyn).HasValues)
                return;
            /*
            {"services":[{"id":4,"name":"GPS навигатор","is_active":1,"is_deleted":0},
            {"id":1,"name":"Без депозита","is_active":1,"is_deleted":0},
            {"id":2,"name":"Без ограничения пробега","is_active":1,"is_deleted":0},
            {"id":3,"name":"Детское кресло","is_active":1,"is_deleted":0}]}
            */
            var services = Model.Services.GetAllByUser(_currentUser.Id);
            if (services == null || !services.Any())
            {
                var service = new Service() { Name = "GPS навигатор", User = _currentUser };
                Model.Services.Post(service);
                var service1 = new Service() { Name = "Без депозита", User = _currentUser };
                Model.Services.Post(service1);
                var service2 = new Service() { Name = "Без ограничения пробега", User = _currentUser };
                Model.Services.Post(service2);
                var service3 = new Service() { Name = "Детское кресло", User = _currentUser };
                Model.Services.Post(service3);
                services = Model.Services.GetAllByUser(_currentUser.Id);
            }            
            foreach (var serv in dyn.services)
            {                
                var service = new Service();
                var id = 0;
                int.TryParse(serv.id.ToString(), out id);
                service.SiteId = id;
                service.Name = serv.name.ToString();
                id = 0;
                int.TryParse(serv.is_active.ToString(), out id);
                service.Status = id == 1;
                id = 0;
                int.TryParse(serv.is_deleted.ToString(), out id);
                if (id == 1)
                    service.Id = -1;                                        
                if (service.Id != -1)
                {                    
                    var servo = services.FirstOrDefault(q => q.Name == service.Name);
                    if (servo != null)
                    {
                        servo.SiteId = service.SiteId;
                    }
                    VLog.Log("Изменяем услугу: "+servo.Name);
                    Model.Services.Put(servo);
                }                
            }
            //
            decoded = GetResponse("https://"+ _serverUrl + "/api/company/service");
            dynamic dyns = JsonConvert.DeserializeObject(decoded);
            if (!((Newtonsoft.Json.Linq.JContainer)dyns).HasValues)
                return;
            /*
            {"services":[{
            "id":1,"companies_id":61,"auto_services_id":4,"price_type":1,"price":1,"is_active":1,"is_deleted":0,
            "created_at":"2016-10-24 19:26:54","updated_at":"2016-10-24 19:28:17"},                               
            */
            var count = dyns.services.Count;            
            if (count == 0)
            {
                foreach (var service in services)
                {
                    service.PriceType += 1;
                    PostService(service);
                    service.PriceType -= 1;
                }
            }
            else
            {
                foreach (var serv in dyns.services)
                {                    
                    var service = new Service();
                    var sid = 0;
                    int.TryParse(serv.auto_services_id.ToString(), out sid);
                    service.SiteId = sid;
                    sid = 0;
                    int.TryParse(serv.price_type.ToString(), out sid);
                    service.PriceType = sid;
                    double price = 0;
                    var pricestr = serv.price.ToString();
                    if (pricestr.Contains("."))
                        pricestr = pricestr.Replace(".",
                            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    else if (pricestr.Contains(","))
                        pricestr = pricestr.Replace(",",
                            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    double.TryParse(pricestr, out price);
                    service.Price = (int)price;
                    sid = 0;
                    int.TryParse(serv.id.ToString(), out sid);
                    service.CompanyId = sid;
                    sid = 0;
                    int.TryParse(serv.is_active.ToString(), out sid);
                    service.Status = sid == 1;
                    sid = 0;
                    int.TryParse(serv.is_deleted.ToString(), out sid);
                    if (sid == 1)
                        service.Id = -1;
                                /*
                                double.TryParse(parvalue, out price);*/                                                                                 
                    if (service.Id != -1)
                    {
                        var servo = services.FirstOrDefault(q => q.SiteId == service.SiteId);
                        if (servo != null)
                        {                            
                            servo.Price = service.Price;
                            servo.PriceType = service.PriceType;
                            servo.Status = service.Status;
                            servo.CompanyId = service.CompanyId;
                        }
                        VLog.Log("Изменяем услугу: " + servo.Name);
                        Model.Services.Put(servo);
                    }
                }
            }            
        }

        private void PostService(Service service)
        {
            var upd = "";
            if (service.CompanyId > 0)
            {
                upd = service.CompanyId + "&";
            }
            var url = string.Format("https://"+ _serverUrl + "/api/company/service?{4}auto_services_id={0}&price_type={1}&price={2}&is_active={3}&is_deleted=0"
                , service.SiteId, service.PriceType, service.Price, service.Status?1:0,upd);         
            var result = PostString(url);
            /*
            {"service":{"companies_id":58,"auto_services_id":"4","price_type":"1","price":"0","is_active":"0",
            "updated_at":"2016-11-04 20:15:32","created_at":"2016-11-04 20:15:32","id":5}}
            */
            var match = Regex.Match(result, "\"id\":.*?",RegexOptions.Singleline);
            if (match != null)
            {
                var line = match.ToString();
                var sid = 0;
                if (line.Contains(','))
                {
                    var pars = line.Split(',');
                    foreach (var par in pars)
                    {
                        if (string.IsNullOrEmpty(par))
                            continue;
                        var parname = par.Split(':')[0].Replace("\"", "");
                        if (string.IsNullOrEmpty(parname))
                            continue;
                        var parvalue = par.Split(':')[1].Replace("\"", "").TrimEnd('}');
                        if (string.IsNullOrEmpty(parvalue))
                            continue;
                        switch (parname)
                        {
                            case "id":
                               int.TryParse(parvalue, out sid);                                
                                break;
                        }
                    }
                }                                              
                if (sid > 0 && sid != service.CompanyId)
                {
                    service.CompanyId = sid;
                    Model.Services.Put(service);
                }
            }
        }

        private void GetUpdates()
        {
            try
            {
                VLog.Log("Проверяем обновления");
                if (first)
                {
                    first = false;
                    try
                    {
                        GetCarRentals();
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                    try
                    {
                        UpdateServices();
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                    try
                    {
                        UpdateClients();
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                    try
                    {
                        UpdateAtts();
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                    try
                    {
                        UpdateCars();
                    }
                    catch (Exception ex)
                    {
                        VLog.Log(ex);
                    }
                    UpdateOrders("");                    
                }
                else
                {                    
                    UpdateOrders($"?start_date={_startDate}");
                }                
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }
            finally
            {
                _startDate = ConvertToTimestamp(DateTime.UtcNow);
            }           
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!showlogin)
            {
                _closing = true;
                _loginForm?.Close();                
            }
        }

        private void ShowSettings()
        {
            var sf = new SettingsForm(_currentUser,this);
            sf.ShowDialog(this);
            try
            {
                var services = Model.Services.GetAllByUser(_currentUser.Id);
                foreach (var service in services)
                {
                    service.PriceType += 1;
                    PostService(service);
                    service.PriceType -= 1;
                }
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //getAllcars();
            //LoadCars();                       
        }

        private void LoadCars()
        {
            gridControlMain.DataSource = null;
            gridViewMain.Columns.Clear();
            gridControlMain.DataSource = _allCars;
            gridViewMain.OptionsView.ColumnAutoWidth = true;
            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
            memoEdit.ReadOnly = true;
            memoEdit.AutoHeight = true;
            memoEdit.ScrollBars = ScrollBars.None;
            memoEdit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            memoEdit.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            memoEdit.WordWrap = true;
            gridViewMain.GridControl.RepositoryItems.Add(memoEdit);
            gridViewMain.Columns["Description"].ColumnEdit = memoEdit;
            gridViewMain.Columns["TO"].ColumnEdit = memoEdit;
            RepositoryItemMemoEdit memoEdit2 = new RepositoryItemMemoEdit();
            memoEdit2.ReadOnly = true;
            memoEdit2.AutoHeight = true;
            memoEdit2.Appearance.ForeColor = Color.LightSkyBlue;
            memoEdit2.ScrollBars = ScrollBars.None;
            memoEdit2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            memoEdit2.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            memoEdit2.WordWrap = true;
            memoEdit2.Enter += MemoEdit2_Enter;
            memoEdit2.Click += MemoEdit2_Enter;
            gridViewMain.Columns["DamageCount"].ColumnEdit = memoEdit2;
            gridViewMain.BestFitColumns(true);
        }

        private void MemoEdit2_Enter(object sender, EventArgs e)
        {
            var row = (Car) gridViewMain.GetFocusedRow();
            if (row == null)
                return;
            DamagesForm df = new DamagesForm(row);
            if (df.ShowDialog(this) == DialogResult.Cancel)
                return;
            gridViewMain.ClearSelection();
            LoadCars();
        }

        private void AddCar()
        {
            var acf = new AddCarForm(_currentUser);
            lock (_allCars)
            {
                if (acf.ShowDialog(this) == DialogResult.Cancel)
                    return;
                _allCars.Add(acf.GetCar);
            }
            LoadCars();
            var th = new Thread(PostCar);
            th.Start(acf.GetCar);
            //PostCar();
        }   

        private void PostCar(object caro)
        {
            try
            {
                Car car = (Car) caro;
                if (_allMarks == null)
                    _allMarks = Model.Marks.GetAll();
                bool update = car.SiteId != 0;
                var upd = update ? $"/{car.SiteId}" :"";
                if (car.CarRental == null)
                {
                    VLog.Log("Машину без пункта выдачи не постим. " + car.Model);
                    return;
                }
                VLog.Log("Постим машину");
                var mark = _allMarks.FirstOrDefault(q => q.Id == car.Model.MarkId);
                var url =
                    string.Format(
                        "https://" + _serverUrl + "/api/company/auto" + upd +
                        "?catalog-car-rental={0}&catalog-auto-brand={1}&catalog-name={2}&catalog-auto-body-type={3}&catalog-auto-transmission={4}&catalog-color={5}"
                        , car.CarRental.SiteId, mark.SiteId, car.Model.Name, car.GetSiteBody, car.Kpp ? 2 : 1,
                        (int) car.Color);
                var result = PostString(url, update);
                if (!update)
                {
                    var match = Regex.Match(result, ",\"id\":.*?}");
                    if (match != null)
                    {
                        var ind = match.ToString().Split(':')[1].Replace("}", "").TrimEnd('}').TrimEnd(',');
                        var sid = 0;
                        int.TryParse(ind, out sid);
                        if (sid > 0 && sid != car.SiteId)
                        {
                            car.SiteId = sid;
                            Model.Cars.Put(car);
                        }
                    }
                }
                car = Model.Cars.Read(car.Id);
                VLog.Log("Постим цены на машину");
                foreach (var rent in car.Rents)
                {
                    update = rent.SiteId != 0;
                    upd = update ? $"/{rent.SiteId}" :"";
                    url =
                        string.Format(
                            "https://" + _serverUrl + "/api/company/rent_price" + upd +
                            "?days_min={0}&days_max={1}&price={2}&is_active={3}&catalog_id={4}"
                            , rent.From, rent.To, rent.Price, rent.Status ? 1 : 0, car.SiteId);
                    result = PostString(url, update);
                    var match = Regex.Match(result, (update ? "" : ",") + "\"id\":.*?" + (update ? "," : "}"));
                    if (match.ToString() != null)
                    {
                        var ind = match.ToString().Split(':')[1].Replace("}", "").TrimEnd(',');
                        var sid = 0;
                        int.TryParse(ind, out sid);
                        if (sid > 0 && sid != car.SiteId)
                        {
                            rent.SiteId = sid;
                            Model.Rents.Put(rent);
                        }
                    }
                }
                updateGraph = true;
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }            
        }
      
        private void LoadClients()
        {
            gridControlMain.DataSource = null;
            gridViewMain.Columns.Clear();
            gridControlMain.DataSource = _allClients;
            gridViewMain.OptionsView.ColumnAutoWidth = false;
            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit
            {
                ReadOnly = true,
                AutoHeight = true,
                ScrollBars = ScrollBars.None
            };
            memoEdit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            memoEdit.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            memoEdit.WordWrap = true;
            memoEdit.Enter += MemoEdit_Enter1;
            memoEdit.Click+= MemoEdit_Enter1;
            gridViewMain.GridControl.RepositoryItems.Add(memoEdit);
            gridViewMain.Columns["ShowName"].ColumnEdit = memoEdit;
            RepositoryItemMemoEdit memoEdit2 = new RepositoryItemMemoEdit
            {
                ReadOnly = true,
                AutoHeight = true,
                ScrollBars = ScrollBars.None
            };
            memoEdit2.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            memoEdit2.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            memoEdit2.WordWrap = true;
            gridViewMain.GridControl.RepositoryItems.Add(memoEdit2);
            memoEdit2.Enter += MemoEdit_Enter;
            memoEdit2.Click += MemoEdit_Enter;
            gridViewMain.Columns["ShowComments"].ColumnEdit = memoEdit2;
            RepositoryItemMemoEdit memoEdit3 = new RepositoryItemMemoEdit
            {
                ReadOnly = true,
                AutoHeight = true,
                ScrollBars = ScrollBars.None
            };
            memoEdit3.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            memoEdit3.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            memoEdit3.WordWrap = true;
            gridViewMain.GridControl.RepositoryItems.Add(memoEdit3);
            memoEdit3.Enter += MemoEdit3_Enter;
            memoEdit3.Click += MemoEdit3_Enter;
            gridViewMain.Columns["ShowHistory"].ColumnEdit = memoEdit3;
            gridViewMain.ClearSelection();
            gridViewMain.BestFitColumns();

        }

        private void MemoEdit_Enter1(object sender, EventArgs e)
        {
            var row = (Client)gridViewMain.GetFocusedRow();
            if (row == null)
                return;
            AddClientForm acf = new AddClientForm(_currentUser,row);
            if (acf.ShowDialog(this) == DialogResult.Cancel)
                return;
            gridViewMain.RefreshData();
            var th = new Thread(PostClient);
            var oldClient = acf.GetOldClient;
            th.Start(new List<object>() { row, oldClient });                       
        }

        private void PostClient(object cliento)
        {
            try
            {
                var client = (Client) ((List < object > )cliento)[0];
                var oldClient = (Client)((List<object>)cliento)[1];
                bool update = client.SiteId != 0;
                if (!update||oldClient==null)
                {
                    VLog.Log("у клиента нет идентификатора, пропускаем");
                    return;
                }
                var upd = update ? $"/{client.SiteId}" :"";
                VLog.Log("Постим клиента " + client.Fio);
                var oldstring=$"old_name={oldClient.Fio}";
                if (!string.IsNullOrEmpty(oldClient.Passport))
                    oldstring+=$"&old_passport_no={oldClient.Passport}";
                if (!string.IsNullOrEmpty(oldClient.Born))
                    oldstring+=$"&old_birth_place={oldClient.Born}";
                if (!string.IsNullOrEmpty(oldClient.License))
                    oldstring+=$"&old_driver_license={oldClient.License}";
                if (!string.IsNullOrEmpty(oldClient.Who))
                    oldstring+=$"&old_issued_by={oldClient.Who}";
                if (oldClient.LicenseDate > DateTime.MinValue)
                    oldstring += $"&old_driver_license_date={oldClient.LicenseDate}";
                if (!string.IsNullOrEmpty(oldClient.Phone))
                    oldstring += $"&old_phone={oldClient.Phone}";
                if (oldClient.When>DateTime.MinValue)
                         oldstring+=$"&old_passport_date={oldClient.When}";
                if (!string.IsNullOrEmpty(oldClient.Registration))
                    oldstring+=$"&old_registration_place={oldClient.Registration}";      
                var url = string.Format("https://" + _serverUrl + "/api/company/client/update?" + oldstring + $"&name={client.Fio}");
                url += $"&birth_place={client.Born}";
                url += $"&phone={client.Phone}";
                  url += $"&passport_no={client.Passport}";                

                  url += $"&driver_license={client.License}";                
                  url += $"&issued_by={client.Who}";                
                  url += $"&driver_license_date={client.LicenseDate}";                
                              
                  url += $"&passport_date={client.When}";                
                  url += $"&registration_place={client.Registration}";                
                var result = PostString(url);
                /*if (!update)
                {
                    var match = Regex.Match(result, ",\"id\":.*?}");
                    if (match != null)
                    {
                        var ind = match.ToString().Split(':')[1].Replace("}", "").TrimEnd('}').TrimEnd(',');
                        var sid = 0;
                        int.TryParse(ind, out sid);
                        if (sid > 0 && sid != client.SiteId)
                        {
                            client.SiteId = sid;
                            Model.Clients.Put(client);
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }
        }

        private void MemoEdit3_Enter(object sender, EventArgs e)
        {
            var row = (Client) gridViewMain.GetFocusedRow();
            if (row == null)
                return;
            ClientOrdersForm cof = new ClientOrdersForm(row.Orders);
            cof.ShowDialog(this);
        }

        private void MemoEdit_Enter(object sender, EventArgs e)
        {
            var row = (Client) gridViewMain.GetFocusedRow();
            if (row == null)
                return;
            if (string.IsNullOrEmpty(row.Comments))
            {
                CommentForm cf = new CommentForm();
                if (cf.ShowDialog(this) == DialogResult.Cancel)
                    return;
                row.Comments = cf.GetComment();
                Model.Clients.Put(row);
                LoadClients();
            }
        }     

        private void AddClient()
        {
            var acf = new AddClientForm(_currentUser);
            if (acf.ShowDialog(this) == DialogResult.Cancel)
                return;
            LoadClients();
          //  var th = new Thread(PostClient);
           // th.Start(acf.GetClient);
        }


        private void EditClient()
        {
            if (gridViewMain.SelectedRowsCount == 0)
            {
                MessageBox.Show(
                    Resources.MainForm_barButtonItemEditClient_ItemClick_Выберите_клиента_для_редактирования_);
                return;
            }
            var idx = gridViewMain.GetSelectedRows()[0];
            var item = (Client) gridViewMain.GetRow(idx);
            var acf = new AddClientForm(_currentUser,item);
            if (acf.ShowDialog(this) == DialogResult.Cancel)
                return;
            LoadClients();
        }

        private void DelClient()
        {
            
        }

        private void DeleteClient()
        {
            if (!gridViewMain.GetSelectedRows().Any())
            {
                MessageBox.Show(Resources.MainForm_barButtonItemDeleteClient_ItemClick_Выберите_клиентов_для_удаления_);
                return;
            }
            try
            {
                var rows = gridViewMain.GetSelectedRows();
                var clients = rows.Select(row => (Client) gridViewMain.GetRow(row)).ToList();
                bool updategraph = false;
                foreach (var client in clients)
                {
                    client.Deleted = true;
                    Model.Clients.Put(client);
                    _allClients.Remove(client);
                    if (client.Orders.Count > 0)
                    {                        
                        updategraph = true;                        
                    }
                }
                if (updategraph)
                {
                    needUpdateOrders = true;
                    needUpdateCars = true;
                }
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
                return;
            }
            LoadClients();
        }      

        private void LoadOrders()
        {
            gridControlMain.DataSource = null;
            gridViewMain.Columns.Clear();           
            gridControlMain.DataSource = _allOrders;
            gridViewMain.OptionsView.ColumnAutoWidth = false;
            gridViewMain.BestFitColumns();
            //
            var col = gridViewMain.Columns.AddVisible("StatusB", "Статус");
            col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            var repButton = new RepositoryItemButtonEdit {Name = "rb1"};
            repButton.Buttons[0].Kind = ButtonPredefines.Glyph;            
            repButton.TextEditStyle = TextEditStyles.HideTextEditor;
            gridViewMain.RowCellClick -= GridViewMain_RowCellClick;
            gridViewMain.RowCellClick += GridViewMain_RowCellClick;            
            gridViewMain.OptionsBehavior.EditorShowMode= EditorShowMode.Click;
            gridControlMain.RepositoryItems.Clear();
            gridControlMain.RepositoryItems.Add(repButton);                        
            col.ColumnEdit = repButton;
            col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            col.Width = 100;
            gridViewMain.CustomUnboundColumnData -= GridViewMain_CustomUnboundColumnData;
            gridViewMain.CustomUnboundColumnData += GridViewMain_CustomUnboundColumnData;
            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit
            {
                ReadOnly = true,
                AutoHeight = true,
                ScrollBars = ScrollBars.None
            };
            memoEdit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            memoEdit.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            memoEdit.WordWrap = true;
            gridViewMain.GridControl.RepositoryItems.Add(memoEdit);
            gridViewMain.Columns["ShowId"].ColumnEdit = memoEdit;
            gridViewMain.Columns["ShowClient"].ColumnEdit = memoEdit;
            gridViewMain.Columns["Fines"].ColumnEdit = memoEdit;
            gridViewMain.Columns["ShowCar"].ColumnEdit = memoEdit;            
        }

        private void GridViewMain_RowCellClick(object sender, RowCellClickEventArgs e)
        {
           if (e.Column.FieldName!= "StatusB")
                return;
            if (e.CellValue != "Завершить")
            {
                e.Handled = true;
                return;
            }                
            var row = (Order)gridViewMain.GetRow(e.RowHandle);
            if (row == null)
                return;
            var cof = new CloseOrderForm(row);
            if (cof.ShowDialog(this) == DialogResult.Cancel)
                return;
            LoadOrders();
        }
       

        private void GridViewMain_CustomUnboundColumnData(object sender,
            DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "StatusB") return;
            var row = (Order) e.Row;
            e.Value = row.ShowStatus;
        }

        private void gridViewMain_CustomDrawCell(object sender,
            DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != xtraTabPageOrders) return;
            if (e.Column.FieldName != "StatusB") return;
            var row = (Order) gridViewMain.GetRow(e.RowHandle);
            if (row == null)
                return;

            var editInfo = (ButtonEditViewInfo) ((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo) e.Cell).ViewInfo;
            editInfo.RightButtons[0].Button.Caption = e.DisplayText;
        }

        private void gridViewMain_ShownEditor(object sender, EventArgs e)
        {
            GridView view = (GridView) sender;
            if (view.FocusedRowHandle < 0)
                return;
            if (xtraTabControl1.SelectedTabPage == xtraTabPageOrders)
            {
                if (view.FocusedColumn.FieldName == "StatusB")
                {
                    ButtonEdit ed = (ButtonEdit) view.ActiveEditor;
                    ed.Properties.Buttons[0].Caption = view.GetFocusedDisplayText();
                }
            }
            else
            {
                if (view.ActiveEditor != null)
                    view.ActiveEditor.Hide();
            }
        }

        private void Exit()
        {
            showlogin = true;
            _loginForm?.ShowLogin();
            Close();
        }

        private void DeleteCar()
        {
            if (!gridViewMain.GetSelectedRows().Any())
            {
                MessageBox.Show(Resources.MainForm_barButtonItemDeleteCars_ItemClick_Выберите_автомобили_для_удаления_);
                return;
            }
            try
            {
                lock (_allCars)
                {
                    var cars = gridViewMain.GetSelectedRows().Select(row => (Car) gridViewMain.GetRow(row)).ToList();
                    bool updateg = false;
                    foreach (var car in cars)
                    {
                        car.Deleted = true;

                        Model.Cars.Put(car);
                        _allCars.Remove(car);
                        if (car.Orders.Count > 0)
                        {
                            updateg = true;
                        }
                    }
                    if (updateg)
                    {
                        needUpdateOrders = true;
                    }
                }
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
                return;
            }
            LoadCars();
        }

        private void gridViewMain_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "DamageCount")
            {
                e.Appearance.ForeColor = Color.LightSkyBlue;
            }
            else if (e.Column.FieldName == "ShowStatusClient")
            {
                var row = (Client) gridViewMain.GetRow(e.RowHandle);
                if (row == null)
                    return;
                switch (row.Status)
                {
                    case ClientStatus.Active:
                        e.Appearance.ForeColor = Color.LimeGreen;
                        break;
                    case ClientStatus.Debtor:
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    case ClientStatus.Refuse:
                        e.Appearance.ForeColor = Color.MediumVioletRed;
                        break;
                }
            }
        }

        private void simpleButtonAddCar_Click(object sender, EventArgs e)
        {
            AddCar();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            _filters[e.PrevPage.TabIndex] = gridViewMain.FindFilterText;
            gridViewMain.FindFilterText = _filters[e.Page.TabIndex];
            if (xtraTabControl1.SelectedTabPage== xtraTabPageCars)
            {
                LoadCars();
                gridControlMain.Parent = xtraTabPageCars;
                gridControlMain.BringToFront();                
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageClients)
            {
                LoadClients();
                gridControlMain.Parent = xtraTabPageClients;
                gridControlMain.BringToFront();             
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageOrders)
            {
                _neworderscount = 0;
                ShowNewOrdersCount();
                LoadOrders();//12sec
                gridControlMain.Parent = xtraTabPageOrders;
                gridControlMain.BringToFront();                
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageRents)
            {
                ShowNow = true;
                //LoadCarGraph();//2.5sec
                updateGraph = true;
            }
        }

        private bool ShowNow = false;


        private int graphYear = 0;
        private int graphMonth = 0;

        public void LoadCarGraph()
        {
            carPanel1.SuspendLayout();
            _init = false;
            if (ShowNow)
            {
                spinEditYear.Value = DateTime.Now.Year;
                comboBoxEditMonths.SelectedIndex = DateTime.Now.Month - 1;
                comboBoxEditMarks.Properties.Items.Clear();
                comboBoxEditMarks.Properties.Items.Add("Все");
                comboBoxEditMarks.Properties.Items.AddRange(_allMarks);
                comboBoxEditModels.Properties.Items.Clear();
                comboBoxEditModels.Properties.Items.Add("Все");
            }
            var rentals = Model.CarRentals.GetbyUser(_currentUser.Id);
            comboBoxEditSpot.Properties.Items.Clear();
            comboBoxEditSpot.Properties.Items.Add("Все");
            comboBoxEditSpot.Properties.Items.AddRange(rentals);
            var year = (int) spinEditYear.Value;
            var month = (comboBoxEditMonths.SelectedIndex<0?0: comboBoxEditMonths.SelectedIndex) + 1;

            var models = _allModels;
            var cars = new List<Car>();
            cars.AddRange(_allCars);
            if (_filteredMark >= 0)
            {
                models = models.Where(q => q.MarkId == _filteredMark).ToArray();
                cars = cars.Where(q => q.Model.MarkId == _filteredMark).ToList();
            }
            comboBoxEditModels.Properties.Items.AddRange(models);
            if (_filteredModel >= 0)
            {
                cars = cars.Where(q => q.Model.Id == _filteredModel).ToList();
            }
            else
            {
                comboBoxEditModels.Text = "Начните вводить модель авто";
            }

            if (_filterBody >= 0)
            {
                cars = cars.Where(q => q.BodyType == (Body) _filterBody).ToList();
            }
            if (_filterKpp >= 0)
            {
                cars = cars.Where(q => q.Kpp == (_filterKpp == 0)).ToList();
            }
            if (_filteredRental > 0)
            {
                cars = cars.Where(q => q.CarRental.Id == _filteredRental).ToList();
            }
        var idx = 0;
            var ctrls = new List<Control>();
            var h = 0;
            var shrink = 0;
            for (int i=0;i<carPanel1.Controls.Count;i++)
            {
                CarControl cc = carPanel1.Controls[i]as CarControl;
                h = cc.Height;
                var car = cc.GetCar();
                var ecar = cars.FirstOrDefault(q => q.Id == car.Id);
                if (ecar == null)
                {
                    carPanel1.Controls.Remove(cc);
                    i--;
                    shrink++;
                }
                else
                {
                    cc.UpdateCar(ecar);
                    if (!ShowNow)
                    {
                        cc.UpdateGraph();
                    }
                    else
                    {
                        cc.ShowMonth(month, year, DateTime.Now.Day);
                    }
                    cars.Remove(ecar);                    
                }
            }
            carPanel1.Height -= h * shrink;
            foreach (var car in cars)
            {
                CarControl cc = new CarControl(_currentUser,car,this);                       
                cc.BringToFront();              
                ctrls.Add(cc);
                h = cc.Height;
                cc.Dock=DockStyle.Top;
                idx++;
                if (idx%2==0)
                    cc.SetColor();
                if (ShowNow)
                    cc.ShowMonth(month, year, DateTime.Now.Day);
                else
                    cc.ShowMonth(month,year);
            }
            carPanel1.Controls.AddRange(ctrls.ToArray());
            carPanel1.Height += h*ctrls.Count;
            if (comboBoxEditMonths.SelectedIndex >= 0)
            {
                var date = new DateTime((int) spinEditYear.Value, comboBoxEditMonths.SelectedIndex + 1, ShowNow ? DateTime.Now.Day:1);
                dateControl1.SetDate(date);
            }
            _init = true;
            carPanel1.ResumeLayout();            
        }


        private void simpleButtonDeleteCar_Click(object sender, EventArgs e)
        {
            DeleteCar();
        }

        private void xtraTabControl1_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            if (e.Button.Caption!="Настройки")
                Exit();
            else
            {
                ShowSettings();
            }
        }

        private void simpleButtonAddClient_Click(object sender, EventArgs e)
        {
            AddClient();
        }

        private void simpleButtonDeleteClient_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }     

        private void gridViewMain_RowStyle(object sender, RowStyleEventArgs e)
        {
            e.Appearance.BackColor = e.RowHandle%2 == 0 ? Color.White : Color.LightGray;
        }

        private void comboBoxEditMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDate();
        }

        private void ChangeDate()
        {
            if (!_init)
                return;
            ShowNow = false;
            var year = (int)spinEditYear.Value;
            var month = comboBoxEditMonths.SelectedIndex+1;
            carPanel1.SuspendLayout();
            foreach (var ctrl in carPanel1.Controls)
            {
                if (!(ctrl is CarControl))
                    continue;
                var cc = (CarControl)ctrl;
                cc.SuspendLayout();
                cc.ShowMonth(month, year);
                cc.ResumeLayout();
            }
            carPanel1.ResumeLayout();
            if (comboBoxEditMonths.SelectedIndex >= 0)
            {
                var date = new DateTime(year, month, 1);
                dateControl1.SetDate(date);
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ChangeDate();
        }

        private void comboBoxEditModels_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (comboBoxEditModels.SelectedIndex <= 0)
            {
                if (_filteredModel != -1)
                {
                    _filteredModel = -1;
                    LoadCarGraph();
                }                
            }
            else
            {
                var id =((CarModel) comboBoxEditModels.SelectedItem).Id;
                if (id != _filteredModel)
                {
                    _filteredModel = id;
                    LoadCarGraph();
                }
            }            
        }

        private int _filteredModel=-1;
        private int _filteredMark=-1;
        private int _filterBody = -1;
        private int _filterKpp = -1;
        private int _filteredRental = -1;

        private void comboBoxEditMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditMarks.SelectedIndex == 0)
            {
                if (_filteredMark != -1)
                {
                    _filteredMark = -1;                    
                    LoadCarGraph();
                }
            }
            else
            {
                var id = ((Mark) comboBoxEditMarks.SelectedItem).Id;
                if (id != _filteredMark)
                {
                    _filteredMark = id;
                    _filteredModel = -1;
                    LoadCarGraph();
                }
            }
        }

        private void comboBoxEditKpp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditKpp.SelectedIndex >= 0)
            {
                _filterKpp = comboBoxEditKpp.SelectedIndex - 1;
                LoadCarGraph();
            }
        }

        private void comboBoxEditBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditBodyType.SelectedIndex >= 0)
            {
                _filterBody = comboBoxEditBodyType.SelectedIndex - 1;LoadCarGraph();
            }
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridViewMain.SelectedRowsCount == 0)
            {
                MessageBox.Show(Resources.MainForm_Р_Выберите_машину_для_редактирования_);
                return;
            }
            var idx = gridViewMain.GetSelectedRows()[0];
            var car = (Car)gridViewMain.GetRow(idx);
            var acf = new AddCarForm(_currentUser, car);
            if (acf.ShowDialog(this) == DialogResult.Cancel)
                return;         
            LoadCars();
            updateGraph = true;
            try
            {                
                var th = new Thread(PostCar);
                th.Start(car);                            
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxEditSpot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditSpot.SelectedIndex <= 0)
            {
                if (_filteredRental != -1)
                {
                    _filteredRental = -1;
                    LoadCarGraph();
                }
            }
            else
            {
                var id = ((CarRental)comboBoxEditSpot.SelectedItem).Id;
                if (id != _filteredRental)
                {
                    _filteredRental = id;
                    LoadCarGraph();
                }
            }
        }

        private void xtraScrollableControl1_Scroll(object sender, XtraScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {            
                xtraScrollableControl2.HorizontalScroll.Value = e.NewValue;
            }
        }

        private void xtraScrollableControl2_Scroll(object sender, XtraScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {               
                xtraScrollableControl1.HorizontalScroll.Value = e.NewValue;
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            xtraScrollableControl2.HorizontalScroll.Value = xtraScrollableControl1.HorizontalScroll.Value;
        }
    }

}
