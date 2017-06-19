using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public enum AttachmentType
    {
        [Description("图片")]
        Img=0,
        [Description("其它")]
        Others=1
    }
}
