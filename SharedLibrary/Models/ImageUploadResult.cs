using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    // this only to use when a image upload is succeed or failed
    // to send message from controller to frontend
    public class ImageUploadResult
    {
        public bool success { get; set; }
    }
}
