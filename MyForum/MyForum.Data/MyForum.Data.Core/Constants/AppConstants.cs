using System.Collections.Generic;

namespace MyForum.Data.Core.Constants
{
    /// <summary>
    ///     Contains plural logic in static class
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        ///     Static string Dictionary
        /// </summary>
        private static readonly Dictionary<string, string> _dictionary =
            new Dictionary<string, string>
            {
                {"MasterAdminUserName", "Administrator"},
                {"MasterAdminRoleName", "admin"},
                {"MasterAdminEmail", "Administrator@gmail.com"},
                {"MasterAdminPhoto", "/Content/Images/default_photo.png"},
                {"MasterAdminStartPassword", "123456"},
                {"ModeratorRoleName", "Moderator"},
                {"UserRoleName", "User"}
            };

        public static Dictionary<string, string> GetConstantsAll => _dictionary;

        /// <summary>
        ///     Access the Dictionary from external sources
        /// </summary>
        public static string GetConstant(string word)
        {
            // Try to get the result in the static Dictionary
            string result;
            return !_dictionary.TryGetValue(word, out result) ? null : result;
        }
    }
}