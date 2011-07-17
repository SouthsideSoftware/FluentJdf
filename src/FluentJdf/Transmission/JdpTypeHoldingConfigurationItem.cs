//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FluentJdf.LinqToJdf;
//using System.Diagnostics;

//namespace FluentJdf.Transmission {

//    /// <summary>
//    /// Summary description for JdpTypeHoldingCofigurationItem.
//    /// </summary>
//    [Serializable]
//    public abstract class JdpTypeHoldingConfigurationItem {
//        /// <summary>
//        /// The JDP class name.
//        /// </summary>
//        protected string _className;

//        /// <summary>
//        /// The assembly name that contains the class.
//        /// </summary>
//        /// <remarks>
//        /// The assembly can be a simple name, which means that the
//        /// corresponding assembly file must be in the same folder
//        /// as the executable, or it can be a fully qualified name, which means
//        /// that the assembly should be registered in the GAC.
//        /// </remarks>
//        protected string _assemblyName;

//        /// <summary>
//        /// The type name associated with the configuration item. 
//        /// </summary>
//        /// <remarks>
//        /// This is a .NET type string in the form [class],[assembly].
//        /// </remarks>
//        protected string _typeName;

//        /// <summary>
//        /// Flag indicates the configuration cannot be modified.
//        /// </summary>
//        protected bool _readOnly = false;

//        /// <summary>
//        /// Construct a type holding configuration item.
//        /// </summary>
//        /// <param name="type">The .NET type string in the form [class],[assembly]. </param>
//        public JdpTypeHoldingConfigurationItem(string type) {
//            _typeName = type;
//            int i = type.IndexOf(",");
//            if (i != -1 && i + 1 < type.Length) {
//                _className = type.Substring(0, i).Trim();
//                _assemblyName = type.Substring(i + 1, type.Length - (i + 1)).Trim();
//            }

//            if (_className == null || _className.Length == 0 || _assemblyName == null || _assemblyName.Length == 0) {
//                throw new JdfException("Configuration item type must be of form <class>,<assembly>.  " + type + " is invalid.");
//            }
//        }

//        /// <summary>
//        /// The class name for this configuration item.
//        /// </summary>
//        public string ClassName {
//            get {
//                return _className;
//            }
//        }

//        /// <summary>
//        /// The assembly name for the configuration item.
//        /// </summary>
//        public string AssemblyName {
//            get {
//                return _assemblyName;
//            }
//        }

//        /// <summary>
//        /// The .NET type name for this configuration item in the form [class],[assembly].
//        /// </summary>
//        public string TypeName {
//            get {
//                return _typeName;
//            }
//        }

//        /// <summary>
//        /// Get a string representation of this object.
//        /// </summary>
//        /// <returns>A string with information about the object.</returns>
//        public override string ToString() {
//            StringBuilder sb = new StringBuilder();
//            sb.AppendFormat("Type: {0} Class: {1} Assembly: {2}",
//                _typeName, _className, _assemblyName);
//            return sb.ToString();
//        }

//        /// <summary>
//        /// Dump diagnostic information to the attached trace listeners.
//        /// </summary>
//        public virtual void Dump() {
//            Trace.WriteLine(this.GetType().Name + " " + ToString());
//        }
//    }
//}

