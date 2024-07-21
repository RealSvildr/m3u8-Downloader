namespace m3u8_Downloader {
    public static class String {
        public static string Replace(this string obj, string[] oldValue, string newValue) {
            foreach (var old in oldValue) {
                obj = obj.Replace(old, newValue);
            }

            return obj;
        }

        public static string Replace(this string obj, string[] oldValue, string[] newValue) {
            if (oldValue.Length <= newValue.Length) {
                for (var i = 0; i < oldValue.Length; i++) {
                    obj = obj.Replace(oldValue[i], newValue[i]);
                }
            } else {
                var j = 0;

                for (var i = 0; i < oldValue.Length; i++) {
                    if (j >= newValue.Length) {
                        j = 0;
                    }

                    obj = obj.Replace(oldValue[i], newValue[j]);

                    j++;
                }
            }

            return obj;
        }
    }
}
