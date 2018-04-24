using mgSoft.BusinessLayer.Core.Results;
using NUnit.Framework;

namespace mgSoft.BusinessLayer.Core.UnitTests
{
    public class ResultMessageTests
    {
        [Test]
        public void EmptyConstructorTest()
        {
            var resultMessage = new ResultMessage();
            Assert.IsInstanceOf<ResultMessage>(resultMessage);
            Assert.IsNull(resultMessage.Message);
            Assert.IsNull(resultMessage.ShortMessage);
            Assert.IsNull(resultMessage.PropertyName);
            Assert.AreEqual(ResultMessageType.Information, resultMessage.MessageType);
        }

        [Test]
        [TestCase(ResultMessageType.Information, "My Short Message", "My Message")]
        //[TestCase(ResultMessageType.Alert, "!@#$%^&*()_+-=`~qwertyuiop[]{}\\|asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKL\"ZXCVBNM<>?", "!@#$%^&*()_+-=`~qwertyuiop[]{}\\|asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKL\"ZXCVBNM<>?")]
        [TestCase(ResultMessageType.Cancel, "Cancel Message", "My Cancel Message")]
        [TestCase(ResultMessageType.Error, "Error Message", "My Error Message")]
        [TestCase(ResultMessageType.Warning, "Warning Message", "My Warning Message")]
        public void TypeStringStringConstructorTest(ResultMessageType type, string shortMessage, string message)
        {
            var resultMessage = new ResultMessage(type, shortMessage, message);
            Assert.IsInstanceOf<ResultMessage>(resultMessage);
            Assert.AreEqual(message, resultMessage.Message);
            Assert.AreEqual(shortMessage, resultMessage.ShortMessage);
            Assert.IsNull(resultMessage.PropertyName);
            Assert.AreEqual(type, resultMessage.MessageType);
        }

        [Test]
        [TestCase(ResultMessageType.Information, "My Short Message", "My Message", "MyProperty")]
        //[TestCase(ResultMessageType.Alert, "!@#$%^&*()_+-=`~qwertyuiop[]{}\\|asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKL\"ZXCVBNM<>?", "!@#$%^&*()_+-=`~qwertyuiop[]{}\\|asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKL\"ZXCVBNM<>?", "!@#$%^&*()_+-=`~qwertyuiop[]{}\\|asdfghjkl;'zxcvbnm,./QWERTYUIOPASDFGHJKL\"ZXCVBNM<>?")]
        [TestCase(ResultMessageType.Cancel, "Cancel Message", "My Cancel Message", "CancelProperty")]
        [TestCase(ResultMessageType.Error, "Error Message", "My Error Message", "ErrorProperty")]
        [TestCase(ResultMessageType.Warning, "Warning Message", "My Warning Message", "WarningProperty")]
        public void TypeStringStringStringConstructorTest(ResultMessageType type, string shortMessage, string message, string propertyName)
        {
            var resultMessage = new ResultMessage(type, shortMessage, message, propertyName);
            Assert.IsInstanceOf<ResultMessage>(resultMessage);
            Assert.AreEqual(message, resultMessage.Message);
            Assert.AreEqual(shortMessage, resultMessage.ShortMessage);
            Assert.AreEqual(propertyName, resultMessage.PropertyName);
            Assert.AreEqual(type, resultMessage.MessageType);
        }
    }
}