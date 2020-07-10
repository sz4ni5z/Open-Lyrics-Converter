using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace OpenLyricsConverter_v2
{
    /// <summary>
    /// Class to manage language switching
    /// </summary>
    class DisplayLanguage : BaseViewModel
    {
        #region Private Members
        Dictionary<string, ILanguages> LanguageCollection;
        string _currentLanguage;
        readonly List<string> ListOfAvailableLanguages;
        #endregion

        #region Properties
        /// <summary>
        /// List of available languages
        /// </summary>
        public List<string> Languages
        {
            get
            {
                return ListOfAvailableLanguages;
            }
        }

        /// <summary>
        /// Pointer to current used language
        /// </summary>
        public string CurrentLanguage
        {
            get
            {
                if(_currentLanguage == null)
                {
                    _currentLanguage = Languages.FirstOrDefault();
                    return _currentLanguage;
                }
                else
                {
                    return _currentLanguage;
                }
            }
            set
            {
                //safety check
                if(Languages.Contains(value))
                {
                    _currentLanguage = value;

                    //we set display language to fire InotifyChange
                    GetDisplayLanguage = LanguageCollection[CurrentLanguage];
                }
                else
                {
                    throw new ArgumentException(value + " is not in language list", value);
                }
            }
        }
        /// <summary>
        /// Set of currently used language
        /// </summary>
        public ILanguages GetDisplayLanguage {
            get
            {
                return LanguageCollection[CurrentLanguage];
            }
            private set
            {
                GetDisplayLanguage = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public DisplayLanguage()
        {
            //create instance
            LanguageCollection = new Dictionary<string,ILanguages >();

            //get all language with using reflection on parent assembly
            var languages = GetTypesWithHelpAttribute(typeof(BaseViewModel).Assembly);

            //create dictionary
            foreach (var i in languages)
            {
                //dynamically create instance of language
                var element = Activator.CreateInstance(i) as ILanguages;

                //get language name using LanguageAttribute
                var languageName = i.GetAttributeValue((LanguageAttribute value) => value.GetName());

                //add language
                LanguageCollection.Add(languageName, element);
            }
            ListOfAvailableLanguages = LanguageCollection.Keys.ToList();
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Helper method to get all classes which marked with LanguageAttribute
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly)
        {
            //Get all classes in assembly
            foreach (Type type in assembly.GetTypes())
            {
                //if implement the attribute return
                if (type.GetCustomAttributes(typeof(LanguageAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
        #endregion
    }
}
