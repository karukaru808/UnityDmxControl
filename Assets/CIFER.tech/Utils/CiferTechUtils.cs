using System.IO;

namespace CIFER.Tech.Utils
{
    /// <summary>
    /// その他全般のUtils
    /// </summary>
    public static class CiferTechUtils
    {
        /// <summary>
        /// pathにフォルダがあるかチェックして、無ければ作るメソッド
        /// パス途中にあるフォルダも一括で作成してくれる
        /// </summary>
        /// <param name="path">フルパス</param>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
            }
        }
    }
}