using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileDataTest
{
    [TestClass]
    public class ProgramTests
    {
       
        [DataRow("s", "test.doc")]
        [DataRow("-s", "test")]
        [DataRow("--s", "test.doct")]
        [DataRow("/s", "t")]
        [DataRow("v", "test.doc")]
        [DataRow("-v", "test")]
        [DataRow("--v", "test.doct")]
        [DataRow("/v", "t")]
        [DataTestMethod]
        public void TestAttributeValidationSuccess(string action, string path)
        {
            //arrange
            //act
            var result = FileData.Program.ValidateArguments(new string[] { action, path });
           
            //assert
            Assert.IsTrue(result,$"Invalid Arguments -  {action} & {path}");
        }

        [DataRow("", "test.doc")]
        [DataRow("-f", "test")]
        [DataRow("--s", "")]
        [DataRow("2019-05-01", "")]
        [DataRow("v", "")]
        [DataRow("", "test.doct")]
        [DataRow("/h", "t")]
        [DataTestMethod]
        public void TestAttributeValidationFailure(string action, string path)
        {
            //arrange
            //act
            var result = FileData.Program.ValidateArguments(new string[] { action, path });
           
            //assert
            Assert.IsFalse(result, $"Invalid Arguments Acceptence -  {action} & {path}");
        }

        [TestMethod]
        public void TestFileDetailsSizeFormat()
        {
         
            //Had ThirdPartyTools included interfaces, i would have mocked them for this test

            //var _mock = new Mock<ThirdPartyTools.FileDetails>();
            //_mock.Setup(x => x.Size(It.IsAny<string>())).Returns(25);
            //_mock.Verify(m => m.Size(It.IsAny<string>()), Times.Once());

            //act
            var result = FileData.Program.ProcessFile(FileData.CheckType.size, "test" );

            //assert
            Assert.IsInstanceOfType(result, typeof(string));
            int tryInt = 0;
            Assert.IsTrue(int.TryParse(result.Split(':')[1], out tryInt));
        }

        [TestMethod]
        public void TestFileDetailsVersionFormat()
        {
            //act
            var result = FileData.Program.ProcessFile(FileData.CheckType.version, "test");

            //assert
            Assert.IsInstanceOfType(result, typeof(string));
            int tryInt = 0;
            Assert.IsFalse(int.TryParse(result.Split(':')[1], out tryInt));         
        }
    }
}
