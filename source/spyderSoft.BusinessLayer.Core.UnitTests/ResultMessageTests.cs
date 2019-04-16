using spyderSoft.BusinessLayer.Core.Results;
using NUnit.Framework;

namespace spyderSoft.BusinessLayer.Core.UnitTests
{
    public class ResultMessageTests
    {
        [Test]
        public void EmptyConstructorTest()
        {
            var resultMessage = new ResultMessage();
            Assert.That(resultMessage, Is.InstanceOf<ResultMessage>());
            Assert.That(resultMessage.Message, Is.Null);
            Assert.That(resultMessage.ShortMessage, Is.Null);
            Assert.That(resultMessage.PropertyName, Is.Null);
            Assert.That(resultMessage.MessageType, Is.EqualTo(ResultMessageType.Information));
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
            Assert.That(resultMessage, Is.InstanceOf<ResultMessage>());
            Assert.That(resultMessage.Message, Is.EqualTo(message));
            Assert.That(resultMessage.ShortMessage, Is.EqualTo(shortMessage));
            Assert.That(resultMessage.PropertyName, Is.Null);
            Assert.That(resultMessage.MessageType, Is.EqualTo(type));
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
            Assert.That(resultMessage, Is.InstanceOf<ResultMessage>());
            Assert.That(resultMessage.Message, Is.EqualTo(message));
            Assert.That(resultMessage.ShortMessage, Is.EqualTo(shortMessage));
            Assert.That(resultMessage.PropertyName, Is.EqualTo(propertyName));
            Assert.That(resultMessage.MessageType, Is.EqualTo(type));
        }
    }
}