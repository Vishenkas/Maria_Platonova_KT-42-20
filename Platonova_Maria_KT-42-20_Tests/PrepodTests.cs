using _1.Models;

namespace Platonova_Maria_KT_42_20_Tests
{
    public class PrepodTests
    {
        [Fact]
        public void Test1()
        {
            var PhoneTest = new Prepod
            {
                Phone = "+7(888)777999"
            };

            var result = PhoneTest.IsValidPhone();

            Assert.False(result);
        }
    }
}