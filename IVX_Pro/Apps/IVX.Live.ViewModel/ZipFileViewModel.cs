using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace IVX.Live.ViewModel {

	public class ZipFileViewModel {
		#region 压缩、解压缩文件
		///
		/// 解压功能(解压压缩文件到指定目录)
		/// 待解压的文件
		/// 指定解压目标目录
		public static bool UnZip(string srcZip, string desPath) {
			//文件不存在 返回
			try {
				if (!Directory.Exists(desPath)) {
					Directory.CreateDirectory(desPath);
				}
			}
			catch (Exception) {
				return false;
			}

			ZipInputStream s = null;
			ZipEntry theEntry = null;
			string fileName;
			FileStream streamWriter = null;
			try {
				s = new ZipInputStream(System.IO.File.OpenRead(srcZip));
				//s.Password = "bocom123";
				while ((theEntry = s.GetNextEntry()) != null) {
					if (theEntry.Name != String.Empty) {
						fileName = Path.Combine(desPath, theEntry.Name);
						///判断文件路径是否是文件夹

						if (fileName.EndsWith("/") || fileName.EndsWith("\\")) {
							Directory.CreateDirectory(fileName);
							continue;
						}

						streamWriter = System.IO.File.Create(fileName);
						int size = 2048;
						byte[] data = new byte[2048];
						while (true) {
							size = s.Read(data, 0, data.Length);
							if (size > 0) {
								streamWriter.Write(data, 0, size);
							}
							else {
								break;
							}
						}
					}
				}
			}
			catch (Exception ex) {
				return false;
			}
			finally {
				if (streamWriter != null) {
					streamWriter.Flush(true);
					streamWriter.Close();
					streamWriter = null;
				}
				if (theEntry != null) {
					theEntry = null;
				}
				if (s != null) {
					s.Close();
					s = null;
				}
				GC.Collect();
				GC.Collect(1);
			}
			return true;
		}
		#endregion
	}
}
