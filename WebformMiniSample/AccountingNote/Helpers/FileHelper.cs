using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AccountingNote.Helps
{
    public class FileHelper
    {
        private const int mbs = 10;
        private const int maxLength = 10 * 1024 * 1024;
        private static string[] _allowFileExt = { ".bmp", ".jpg", ".png" };

        /// <summary> 取得新檔名 </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public static string GetneFileName(FileUpload fileUpload)
        {
            // 重名的解一：
            System.Threading.Thread.Sleep(4);

            // 重名的解二：
            string seqText = new Random((int)DateTime.Now.Ticks).Next(0, 1000).ToString().PadLeft(3, '0');

            string orgFileName = fileUpload.FileName;
            string ext = System.IO.Path.GetExtension(orgFileName);
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFFF") + seqText + ext;
            return newFileName;
        }

        /// <summary> 驗證上傳的檔案 </summary>
        /// <param name="fileUpload"></param>
        /// <param name="msgList">回傳的錯誤訊息</param>
        /// <returns></returns>
        public static bool ValidFileUpload(FileUpload fileUpload, out List<string> msgList)
        {
            msgList = new List<string>();

            if (!ValidFileExt(fileUpload.FileName))
                msgList.Add("Only allow .bmp .jpg .png");

            if (!ValidFileLength(fileUpload.FileBytes))
                msgList.Add("Only allow Length: " + mbs + "MB");

            if (msgList.Any())
                return false;
            else
                return true;
        }

        /// <summary>驗證檔案長度</summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        private static bool ValidFileLength(byte[] fileContent)
        {
            if (fileContent.Length > maxLength)
                return false;
            else
                return true;
        }

        /// <summary> 驗證副檔名 </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool ValidFileExt(string fileName)
        {
            // 含有 .
            string ext = System.IO.Path.GetExtension(fileName);

            if (!_allowFileExt.Contains(ext.ToLower()))
                return false;
            else
                return true;
        }
    }
}