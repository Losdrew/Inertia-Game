﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyGame {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyGame.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to                Controls
        ///    
        ///          0       1       2
        ///       Left Up    ↑   Right Up
        ///    
        ///          3               4
        ///          ←               →
        ///    
        ///          5       6       7 
        ///      Left Down   ↓   Right Down
        ///    
        ///          R               F
        ///     Pause Music     Switch Music.
        /// </summary>
        public static string ControlsTip {
            get {
                return ResourceManager.GetString("ControlsTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream GameOver {
            get {
                return ResourceManager.GetStream("GameOver", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to             ▄▄▄▄▄
        ///        ▄███▀▀▀▀███
        ///       ███       ▀▀▀    ▄▄▄▄▄▄     ▄▄ ▄▄▄▄▄  ▄▄▄▄      ▄▄▄▄▄            ▄▄▄▄▄▄    ▄▄      ▄▄    ▄▄▄▄▄      ▄▄ ▄▄▄
        ///      ███              ██▀  ███    ███▀▀▀███▀▀▀███   ██▀▀▀▀██         ███▀▀▀▀██   ███    ██▀  ▄██▀ ▀███   ████▀▀▀
        ///      ██▌    ██████    ▄▄▄▄▄███   ██▌   ███    ██▌  ███▄▄▄▄██▌       ███     ███   ██   ██   ███▄▄▄▄███  ▐██▌
        ///      ███       ██▌  ▄██▀   ██▌  ▐██    ██▌   ▐██  ▐██▀              ██▌     ██▌   ██▌▄██    ███▀        ██▌
        ///       ████▄▄▄████    [rest of string was truncated]&quot;;.
        /// </summary>
        public static string GameOverScreen {
            get {
                return ResourceManager.GetString("GameOverScreen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 	  ▄▄▄▄▄                                                                    ▄▄▄▄
        ///         ▐████▌                                                          ▄▄█      ████▌
        ///         █████                                                         ████▌       
        ///         ████▌    ▄▄▄▄   ▄▄███▄▄         ▄▄████▄▄        ▄▄▄▄  ▄▄██ ▄▄▄████▄▄▄   ▄▄▄▄       ▄▄▄████▄▄ 
        ///        █████     ████████▀██████     ▄███████████▄     ▐████▄█████ █████████▌   ████     █████▀▀▀█████
        ///        ████▌    ▐█████     ▐████    ████▀      [rest of string was truncated]&quot;;.
        /// </summary>
        public static string MainMenuScreen {
            get {
                return ResourceManager.GetString("MainMenuScreen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music1 {
            get {
                return ResourceManager.GetStream("Music1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music2 {
            get {
                return ResourceManager.GetStream("Music2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music3 {
            get {
                return ResourceManager.GetStream("Music3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music4 {
            get {
                return ResourceManager.GetStream("Music4", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music5 {
            get {
                return ResourceManager.GetStream("Music5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music6 {
            get {
                return ResourceManager.GetStream("Music6", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music7 {
            get {
                return ResourceManager.GetStream("Music7", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music8 {
            get {
                return ResourceManager.GetStream("Music8", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Music9 {
            get {
                return ResourceManager.GetStream("Music9", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Prize {
            get {
                return ResourceManager.GetStream("Prize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 	Score: .
        /// </summary>
        public static string Score {
            get {
                return ResourceManager.GetString("Score", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Stop {
            get {
                return ResourceManager.GetStream("Stop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Wall {
            get {
                return ResourceManager.GetStream("Wall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream Win {
            get {
                return ResourceManager.GetStream("Win", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to       ▀███       ▄███▀                                                               ███▌                    ▐███ 
        ///       ▀███     ████▀                                                                                        ███▌
        ///        ████  ▄███▀     ▄███████▄      ▐███    ▐███           ███    ▐███     ███▌  ███▌   ▐███ ▄█████▄     ▐███
        ///         ████████     ████▀   ▀███▌    ███▌    ███▌           ███    ████▌   ███▌  ▐███    ████▀▀   ███▌    ▐██ 
        ///          █████▀     ████      ▐███   ▐███     ███    [rest of string was truncated]&quot;;.
        /// </summary>
        public static string WinScreen {
            get {
                return ResourceManager.GetString("WinScreen", resourceCulture);
            }
        }
    }
}
