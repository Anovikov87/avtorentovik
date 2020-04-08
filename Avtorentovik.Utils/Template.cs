using System.ComponentModel;

namespace Avtorentovik.Utils
{
    public class Template
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public byte[] File { get; set; }
        [Browsable(false)]
        public User User { get; set; }
    }
}
