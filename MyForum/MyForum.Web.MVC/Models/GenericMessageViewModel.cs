using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Web.MVC.Models
{
    public class GenericMessageViewModel
    {
        public GenericMessageViewModel()
        {
            MessageType = GenericMessages.Info;
        }
        public string Message { get; set; }
        public GenericMessages MessageType { get; set; }
        //public string RedirectTo { get; set; }
    }

    public enum GenericMessages
    {
        Warning,
        Danger,
        Success,
        Info
    }
}