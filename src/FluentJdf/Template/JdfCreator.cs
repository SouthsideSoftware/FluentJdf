//using System;
//using System.IO;
//using System.Collections.Specialized;
//using System.Data;

////TODO: Fix all XML comments -- this now returns tree and not element objects

//namespace FluentJdf.Template
//{
//    /// <summary>
//    /// Creates JDF jobs based on a specially-formatted JDF template
//    /// </summary>
//    public class JdfCreator
//    {
//        /// <summary>
//        /// Removes a cached template from the cache if it exists.
//        /// </summary>
//        /// <param name="templateFileName">The full path to the template file.</param>
//        /// <remarks>
//        /// If the template does not exist in the cache, nothing is done.
//        /// </remarks>
//        public static void InvalidateCache(string templateFileName)
//        {
//            Cache.Remove(Template.GetCacheKey(templateFileName));
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  All ID attributes in the template will be replaced by new unique IDs.  
//        /// All references will be adjusted as appropriate.  The template file is cached as long as the template file does not change.
//        /// </summary>
//        /// <param name="templateFileName">The full file name of the template JDF XML file used to create this job.</param>
//        /// <param name="nameValues">The parameters passed to the template in the form of a StringDictionary using the parameter names as the keys.</param>
//        /// <returns>An Element object that represents the root of the JDF tree</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, true);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  All ID attributes in the template will be replaced by new unique IDs.  
//        /// All references will be adjusted as appropriate.  The template file is cached as long as the template file does not change.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet"></param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, true);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  All ID attributes in the template will be replaced by new unique IDs.  
//        /// All references will be adjusted as appropriate.  The template file is cached as long as the template file does not change.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, string jobId)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, null, jobId);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  All ID attributes in the template will be replaced by new unique IDs.  
//        /// All references will be adjusted as appropriate.  The template file is cached as long as the template file does not change.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet">A DataSet containing one or more tables used by the queue as entries table replacements.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, string jobId)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, SchemaPriority.System, jobId, true, true);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  The template file is cached as long as the template file does not change.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, bool fixupIds)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, SchemaPriority.System, fixupIds, true);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  The template file is cached as long as the template file does not change.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet"></param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, bool fixupIds)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, SchemaPriority.System, fixupIds, true);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>		
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, SchemaPriority.System, fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.  
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet">A DataSet containing one or more tables used by the queue as entries table replacements.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, SchemaPriority.System, fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, string jobId, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, null, SchemaPriority.System, jobId, fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet">A DataSet containing one or more tables used by the queue as entries table replacements.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, string jobId, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, SchemaPriority.System, jobId, fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="priority">Indicates the prioritized schema location.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, SchemaPriority priority, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, null, priority, "G" + Guid.NewGuid().ToString(), fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet">A DataSet containing one or more tables used by the queue as entries table replacements.</param>
//        /// <param name="priority">Indicates the prioritized schema location.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, SchemaPriority priority, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, priority, "G" + Guid.NewGuid().ToString(), fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// Creates a JDF job based on an existing JDF XML template.
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="priority">Indicates the prioritized schema location.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree.</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, SchemaPriority priority, string jobId, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, null, priority, jobId, fixupIds, cacheTemplate);
//        }

//        /// <summary>
//        /// <para>
//        /// Creates a JDF job based on an existing JDF XML template.  
//        /// </para>
//        /// <para>
//        /// You create a template from a copy of a valid JDF job.  Any attribute that you may want to replace should be marked by [:replacement variable name:].  
//        /// If you would like a default value, just place it after the an equals sign and before the closing ":]".  For example, you might have an attribute that 
//        /// looks like attribute="value".  You can mark it for unconditional replacement by changing it to attribute="[:replacementName:]".  
//        /// If you would like it to have a default value of "foo", you would use "[:replacementName=foo:]" instead.
//        /// </para>
//        /// <para>
//        /// Replacement variables without default values are considered required; if you do not provide a replacement, an exception will be thrown.
//        /// </para>
//        /// <para>
//        /// All ID attributes in the template will be replaced by new unique IDs.  All references will be adjusted as appropriate.
//        /// </para>
//        /// <para>
//        /// After replacement, the JDF is saved as XML and then loaded by the parser.  The parser checks syntax during the load.  Parsing errors will be
//        /// contained as usual in the error collection of the element.  
//        /// </para>
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet">A DataSet containing one or more tables used by the queue as entries table replacements.</param>
//        /// <param name="priority">Indicates the prioritized schema location.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <returns>An Element object that represents the root of the JDF tree</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, SchemaPriority priority, string jobId, bool fixupIds, bool cacheTemplate)
//        {
//            return CreateFromTemplate(templateFileName, nameValues, dataSet, priority, jobId, fixupIds, cacheTemplate, Config.AutoInvalidateTemplateCache);
//        }

//        /// <summary>
//        /// <para>
//        /// Creates a JDF job based on an existing JDF XML template.  
//        /// </para>
//        /// <para>
//        /// You create a template from a copy of a valid JDF job.  Any attribute that you may want to replace should be marked by [:replacement variable name:].  
//        /// If you would like a default value, just place it after the an equals sign and before the closing ":]".  For example, you might have an attribute that 
//        /// looks like attribute="value".  You can mark it for unconditional replacement by changing it to attribute="[:replacementName:]".  
//        /// If you would like it to have a default value of "foo", you would use "[:replacementName=foo:]" instead.
//        /// </para>
//        /// <para>
//        /// Replacement variables without default values are considered required; if you do not provide a replacement, an exception will be thrown.
//        /// </para>
//        /// <para>
//        /// All ID attributes in the template will be replaced by new unique IDs.  All references will be adjusted as appropriate.
//        /// </para>
//        /// <para>
//        /// After replacement, the JDF is saved as XML and then loaded by the parser.  The parser checks syntax during the load.  Parsing errors will be
//        /// contained as usual in the error collection of the element.  
//        /// </para>
//        /// </summary>
//        /// <param name="templateFileName">The fully qualified path to the template file.</param>
//        /// <param name="nameValues">A StringDictionary that is keyed by name and contains values.  This method will replace [:name:] in the template with value.</param>
//        /// <param name="dataSet">A DataSet containing one or more tables used by the queue as entries table replacements.</param>
//        /// <param name="priority">Indicates the prioritized schema location.</param>
//        /// <param name="jobId">The unique JobID of the new job.</param>
//        /// <param name="fixupIds">Indicates if the ID attributes will be replaced by new unique IDs.</param>
//        /// <param name="cacheTemplate">Indicates if the template should be retrieved from cache, <i>true</i>, or from disk, <i>false</i>.</param>
//        /// <param name="autoInvalidateCache">True to make the cache dependant on the underlying template file.</param>
//        /// <returns>An Element object that represents the root of the JDF tree</returns>
//        public static JdfTree CreateFromTemplate(string templateFileName, StringDictionary nameValues, DataSet dataSet, SchemaPriority priority, 
//            string jobId, bool fixupIds, bool cacheTemplate, bool autoInvalidateCache)
//        {
//            Template templ = GetTemplate(templateFileName, cacheTemplate, autoInvalidateCache);

//            if (nameValues == null)
//            {
//                nameValues = new StringDictionary();
//            }

//            JdfTree tree = templ.Generate(nameValues, dataSet, priority, fixupIds, jobId);

//            return tree;
//        }


//        /// <summary>
//        /// Fetches a template object based on fileName.  Caches 
//        /// the template if it is not yet in the cache and makes the cache
//        /// dependent upon the underlying template file.
//        /// </summary>
//        /// <remarks>
//        /// This method allows you to programmatically examine the Template.  If all you need
//        /// to do is generate a JDF, use CreateFromTemplate instead.
//        /// </remarks>
//        /// <param name="fileName">The fileName of the template to retreive.</param>
//        /// <returns>A parsed template object.</returns>
//        public static Template GetTemplate(string fileName)
//        {
//            return GetTemplate(fileName, true, true);
//        }

//        /// <summary>
//        /// Fetches a template object based on fileName.  Caches 
//        /// the template if desired and makes the cache
//        /// dependent upon the underlying template file.
//        /// </summary>
//        /// <remarks>
//        /// This method allows you to programmatically examine the Template.  If all you need
//        /// to do is generate a JDF, use CreateFromTemplate instead.
//        /// </remarks>
//        /// <param name="fileName">The fileName of the template to retreive.</param>
//        /// <param name="cacheTemplate">Does not cache the template if this parameter is false.</param>
//        /// <returns>A parsed template object.</returns>
//        public static Template GetTemplate(string fileName, bool cacheTemplate)
//        {
//            return GetTemplate(fileName, cacheTemplate, true);
//        }

//        /// <summary>
//        /// Fetches a template object based on fileName. 
//        /// </summary>
//        /// <remarks>
//        /// This method allows you to programmatically examine the Template.  If all you need
//        /// to do is generate a JDF, use CreateFromTemplate instead.
//        /// </remarks>
//        /// <param name="templateFileName">The fileName of the template to retreive.</param>
//        /// <param name="cacheTemplate">Does not cache the template if this parameter is false.</param>
//        /// <param name="autoInvalidateCache">True to make the cache dependant on the underlying template file.</param>
//        /// <returns>A parsed template object.</returns>
//        public static Template GetTemplate(string templateFileName, bool cacheTemplate, bool autoInvalidateCache)
//        {
//            Template templ = null;
//            bool isCached = false;

//            string cacheKey = Template.GetCacheKey(templateFileName);

//            if (cacheTemplate)
//            {
//                templ = (Template)Cache.GetObject(cacheKey);
//            }

//            if (templ == null)
//            {
//                templ = new Template(templateFileName);
//            } 
//            else 
//            {
//                isCached = true;
//            }

//            if (cacheTemplate && !isCached)
//            {
//                //Cache.Remove(cacheKey);
//                if (!autoInvalidateCache)
//                {
//                    Cache.Add(cacheKey, templ);
//                } 
//                else 
//                {
//                    if (Path.IsPathRooted(templateFileName))
//                    {
//                        templateFileName = Path.GetFullPath(templateFileName);
//                    }
//                    Cache.Add(cacheKey, templ, new FileDependency(Path.GetFullPath(templateFileName)), CacheItemPriority.Normal, null);
//                }
//            }

//            return templ;
//        }
//    }
//}
