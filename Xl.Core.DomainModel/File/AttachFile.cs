using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.DomainModel.File
{
    /// <summary>
    /// 文件附件 
    ///</summary>
    public class AttachFile
    {
        /// <summary>
        /// 唯一标识
        /// <summary>
        public long FileId { get; set; }
        /// <summary>
        /// 原始文件名称
        /// <summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件后缀名
        /// <summary>
        public string Suffix { get; set; }
        /// <summary>
        /// 文件一级分类代码
        /// <summary>
        public string ClassCode1 { get; set; }
        /// <summary>
        /// 文件二级分类代码
        /// <summary>
        public string ClassCode2 { get; set; }
        /// <summary>
        /// 文件大小  (单位：字节)
        /// <summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 本地路径  格式为"一级分类代码/二级分类代码/上传日期/fileId.文件后缀名",如"ep/arc/20171127/6187982494351360.docx"
        /// <summary>
        public string LocalPath { get; set; }
        /// <summary>
        /// 服务器虚拟路径
        /// <summary>
        public string VirtualPath { get; set; }
        /// <summary>
        /// 上传时间
        /// <summary>
        public long UploadTime { get; set; }
        /// <summary>
        /// 文件说明
        /// <summary>
        public string Remark { get; set; }
        /// <summary>
        /// 文件类型   1 副文本文件  0  下载文件
        /// <summary>
        public int Type { get; set; }
    }
}
