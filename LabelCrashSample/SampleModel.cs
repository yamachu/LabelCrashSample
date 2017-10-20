using System;
namespace LabelCrashSample
{
    public class SampleModel
    {
        public string Content { get; set; }
        public string GroupKey
        {
            get
            {
                return Content.ToCharArray()[0].ToString();
            }
        }
    }
}
