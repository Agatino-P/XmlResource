using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Reflection;

//string resourceName = "Namespace.Prefix.FileName.xml";
//Assembly someAssembly = LoadYourAssemblyContainingTheResource();
//XmlDocument xml = new XmlDocument();
//using (Stream resourceStream = someAssembly.GetManifestResourceStream(resourceName))
//{
//    xml.Load(resourceStream);
//}
//// The embedded XML resource is now available in: xml
//If the resource you're loading is embedded in your own assembly, 
//you can do something like Assembly.GetExecutingAssembly() to achieve what I listed as LoadYourAssemblyContainingTheResource() above, 
//or possibly typeof(SomeTypeInYourResourceAssembly).Assembly

namespace TestProj
{
    [TestFixture]
    public class ResourceFile
    {
        [Test]
        public void ReadResource()
        {
            string fileContent = null;
            for (int i = 0; i < 1000; i++)
            {
                fileContent = ReadResource("File1.txt");
            }
            Assert.AreEqual(fileContent, "Pippo");
        }

        public string ReadResource(string fileName)
        {
            // Determine path
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = fileName;
            // Format: "{Namespace}.{Folder}.{filename}.{Extension}"
            resourcePath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(fileName));

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        [Test]
        public void ReadFile()
        {
            string fileContent = null;
            for (int i = 0; i < 1000; i++)
            {
                fileContent = File.ReadAllText(@"D:\Git Local Repository\XmlResource\XmlResource\bin\Debug\File1.txt");
            }


            Assert.AreEqual(fileContent, "Pippo");
        }
    }

}
