using System;

namespace LogServiceAPI.Models
{
    public class Parameters
    {
        public string FilePath { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
