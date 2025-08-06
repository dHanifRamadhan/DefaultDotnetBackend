using DefaultDotnetBackend.Constants;

namespace DefaultDotnetBackend {
    public static class FileContentType {
        public static string GetMimeType(string fileName) {
            var extension = Path.GetExtension(fileName).ToLower();
            return extension switch {
                // 📄 Text
                ExtensionType.Txt => MimeType.Text,
                ExtensionType.Html => MimeType.Html,
                ExtensionType.Css => MimeType.Css,
                ExtensionType.Js => MimeType.Js,
                ExtensionType.Json => MimeType.Json,
                ExtensionType.Xml => MimeType.Xml,
                ExtensionType.Csv => MimeType.Csv,
                ExtensionType.Md => MimeType.Markdown,
                ExtensionType.Rtf => MimeType.Rtf,

                // 📑 Document
                ExtensionType.Pdf => MimeType.Pdf,
                ExtensionType.Doc => MimeType.Doc,
                ExtensionType.Docx => MimeType.Docx,
                ExtensionType.Xls => MimeType.Xls,
                ExtensionType.Xlsx => MimeType.Xlsx,
                ExtensionType.Ppt => MimeType.Ppt,
                ExtensionType.Pptx => MimeType.Pptx,
                ExtensionType.Odt => MimeType.Odt,
                ExtensionType.Epub => MimeType.Epub,

                // 🖼️ Image
                ExtensionType.Jpg => MimeType.Jpg,
                ExtensionType.Jpeg => MimeType.Jpeg,
                ExtensionType.Png => MimeType.Png,
                ExtensionType.Gif => MimeType.Gif,
                ExtensionType.Bmp => MimeType.Bmp,
                ExtensionType.Svg => MimeType.Svg,
                ExtensionType.Webp => MimeType.Webp,
                ExtensionType.Tiff => MimeType.Tiff,
                ExtensionType.Heic => MimeType.Heic,
                ExtensionType.Ico => MimeType.Ico,

                // 🎵 Audio
                ExtensionType.Mp3 => MimeType.Mp3,
                ExtensionType.Wav => MimeType.Wav,
                ExtensionType.Ogg => MimeType.Ogg,
                ExtensionType.M4a => MimeType.M4a,
                ExtensionType.Flac => MimeType.Flac,
                ExtensionType.Aac => MimeType.Aac,
                ExtensionType.Midi => MimeType.Midi,

                // 🎥 Video
                ExtensionType.Mp4 => MimeType.Mp4,
                ExtensionType.Avi => MimeType.Avi,
                ExtensionType.Mov => MimeType.Mov,
                ExtensionType.Mkv => MimeType.Mkv,
                ExtensionType.Wmv => MimeType.Wmv,
                ExtensionType.Webm => MimeType.Webm,
                ExtensionType.Mpeg => MimeType.Mpeg,
                ExtensionType.Flv => MimeType.Flv,
                ExtensionType._3gp => MimeType._3gp,

                // 📦 Archive
                ExtensionType.Zip => MimeType.Zip,
                ExtensionType.Rar => MimeType.Rar,
                ExtensionType._7z => MimeType._7z,
                ExtensionType.Gz => MimeType.Gz,
                ExtensionType.Tar => MimeType.Tar,
                ExtensionType.Bz2 => MimeType.Bz2,
                ExtensionType.Iso => MimeType.Iso,
                ExtensionType.Bin => MimeType.Bin,

                // 🖥️ Application
                ExtensionType.Exe => MimeType.Exe,
                ExtensionType.Apk => MimeType.Apk,
                ExtensionType.Deb => MimeType.Deb,

                // 🎨 Design & Font
                ExtensionType.Psd => MimeType.Psd,
                ExtensionType.Ai => MimeType.Ai,
                ExtensionType.Woff => MimeType.Woff,
                ExtensionType.Woff2 => MimeType.Woff2,

                _ => Messages.WARN_NOT_FOUND
            };
        }

        public static string GetExtensionType(string mimeType) {
            return mimeType switch {
                // 📄 Text
                MimeType.Text => ExtensionType.Txt,
                MimeType.Html => ExtensionType.Html,
                MimeType.Css => ExtensionType.Css,
                MimeType.Js => ExtensionType.Js,
                MimeType.Json => ExtensionType.Json,
                MimeType.Xml => ExtensionType.Xml,
                MimeType.Csv => ExtensionType.Csv,
                MimeType.Markdown => ExtensionType.Md,
                MimeType.Rtf => ExtensionType.Rtf,

                // 📑 Document
                MimeType.Pdf => ExtensionType.Pdf,
                MimeType.Doc => ExtensionType.Doc,
                MimeType.Docx => ExtensionType.Docx,
                MimeType.Xls => ExtensionType.Xls,
                MimeType.Xlsx => ExtensionType.Xlsx,
                MimeType.Ppt => ExtensionType.Ppt,
                MimeType.Pptx => ExtensionType.Pptx,
                MimeType.Odt => ExtensionType.Odt,
                MimeType.Epub => ExtensionType.Epub,

                // 🖼️ Image
                MimeType.Jpeg => ExtensionType.Jpeg,
                MimeType.Png => ExtensionType.Png,
                MimeType.Gif => ExtensionType.Gif,
                MimeType.Bmp => ExtensionType.Bmp,
                MimeType.Svg => ExtensionType.Svg,
                MimeType.Webp => ExtensionType.Webp,
                MimeType.Tiff => ExtensionType.Tiff,
                MimeType.Heic => ExtensionType.Heic,
                MimeType.Ico => ExtensionType.Ico,

                // 🎵 Audio
                MimeType.Mp3 => ExtensionType.Mp3,
                MimeType.Wav => ExtensionType.Wav,
                MimeType.Ogg => ExtensionType.Ogg,
                MimeType.M4a => ExtensionType.M4a,
                MimeType.Flac => ExtensionType.Flac,
                MimeType.Aac => ExtensionType.Aac,
                MimeType.Midi => ExtensionType.Midi,

                // 🎥 Video
                MimeType.Mp4 => ExtensionType.Mp4,
                MimeType.Avi => ExtensionType.Avi,
                MimeType.Mov => ExtensionType.Mov,
                MimeType.Mkv => ExtensionType.Mkv,
                MimeType.Wmv => ExtensionType.Wmv,
                MimeType.Webm => ExtensionType.Webm,
                MimeType.Mpeg => ExtensionType.Mpeg,
                MimeType.Flv => ExtensionType.Flv,
                MimeType._3gp => ExtensionType._3gp,

                // 📦 Archive
                MimeType.Zip => ExtensionType.Zip,
                MimeType.Rar => ExtensionType.Rar,
                MimeType._7z => ExtensionType._7z,
                MimeType.Gz => ExtensionType.Gz,
                MimeType.Tar => ExtensionType.Tar,
                MimeType.Bz2 => ExtensionType.Bz2,
                MimeType.Iso => ExtensionType.Iso,
                MimeType.Bin => ExtensionType.Bin,

                // 🖥️ Application
                MimeType.Exe => ExtensionType.Exe,
                MimeType.Apk => ExtensionType.Apk,
                MimeType.Deb => ExtensionType.Deb,

                // 🎨 Design & Font
                MimeType.Psd => ExtensionType.Psd,
                MimeType.Ai => ExtensionType.Ai,
                MimeType.Woff => ExtensionType.Woff,
                MimeType.Woff2 => ExtensionType.Woff2,

                _ => Messages.WARN_NOT_FOUND
            };
        }
    }
}