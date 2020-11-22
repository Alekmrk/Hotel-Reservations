using Hotel_Reservations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hotel_Reservations_tests
{
    [TestClass]
    public class Hotel_Reservations_Tests
    {
        [TestMethod]
        public void Test1()
        {
            // 1a/1b: Requests outside our planning period are declined
            Hotel hotel1 = new Hotel(1);
            Assert.IsFalse(hotel1.ReserveRoom(-4, 2));
            Assert.IsFalse(hotel1.ReserveRoom(200, 400));
        }

        [TestMethod]
        public void Test2()
        {
            // Requests are accepted
            Hotel hotel2 = new Hotel(3);
            Assert.IsTrue(hotel2.ReserveRoom(0, 5));
            Assert.IsTrue(hotel2.ReserveRoom(7, 13));
            Assert.IsTrue(hotel2.ReserveRoom(3, 9));
            Assert.IsTrue(hotel2.ReserveRoom(5, 7));
            Assert.IsTrue(hotel2.ReserveRoom(6, 6));
            Assert.IsTrue(hotel2.ReserveRoom(0, 4));


        }
        [TestMethod]
        public void Test3()
        {
            // Requests are declined
            Hotel hotel3 = new Hotel(3);
            Assert.IsTrue(hotel3.ReserveRoom(1, 3));
            Assert.IsTrue(hotel3.ReserveRoom(2, 5));
            Assert.IsTrue(hotel3.ReserveRoom(1, 9));
            Assert.IsFalse(hotel3.ReserveRoom(0, 15));


        }
        [TestMethod]
        public void Test4()
        {
            // Requests can be accepted after a decline
            Hotel hotel4 = new Hotel(3);
            Assert.IsTrue(hotel4.ReserveRoom(1, 3));
            Assert.IsTrue(hotel4.ReserveRoom(0, 15));
            Assert.IsTrue(hotel4.ReserveRoom(1, 9));
            Assert.IsFalse(hotel4.ReserveRoom(2, 5));
            Assert.IsTrue(hotel4.ReserveRoom(4, 9));


        }
        [TestMethod]
        public void Test5()
        {
            // Complex Requests
            Hotel hotel5 = new Hotel(2);
            Assert.IsTrue(hotel5.ReserveRoom(1, 3));
            Assert.IsTrue(hotel5.ReserveRoom(0, 4));
            Assert.IsFalse(hotel5.ReserveRoom(2, 3));
            Assert.IsTrue(hotel5.ReserveRoom(5, 5));
            Assert.IsTrue(hotel5.ReserveRoom(4, 10));
            Assert.IsTrue(hotel5.ReserveRoom(10, 10));
            Assert.IsTrue(hotel5.ReserveRoom(6, 7));
            Assert.IsFalse(hotel5.ReserveRoom(8, 10));
            Assert.IsTrue(hotel5.ReserveRoom(8, 9));
        }
    }
}
