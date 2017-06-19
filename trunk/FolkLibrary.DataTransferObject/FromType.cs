using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public enum FromType
    {
        [Description("相关新闻")]
        FriendNews = 0,
        [Description("图书馆")]
        FolkLibray = 1,
        [Description("公益项目")]
        Project = 2,
        [Description("相关单位")]
        FriendDepartment=3,
    }
}
