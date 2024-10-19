namespace ConsoleApp1
{
    using System;
    using System.Threading;

    internal class Program
    {
        private static Semaphore semaphore1 = new Semaphore(1, 1); // Semaphore cho process A
        private static Semaphore semaphore2 = new Semaphore(0, 1); // Semaphore cho process B
        private static Semaphore semaphore3 = new Semaphore(0, 1); // Semaphore cho process C
        private static int a = 6;

        static void Main(string[] args)
        {
            Thread threadA = new Thread(ProcessA);
            Thread threadB = new Thread(ProcessB);
            Thread threadC = new Thread(ProcessC);
            //--------ACB---------
            //threadA.Start(); // Khởi động Process A
            //threadC.Start(); // Khởi động Process B
            //threadB.Start(); // Khởi động Process C

            //threadA.Join(); // Đợi Process A hoàn thành
            //threadC.Join(); // Đợi Process B hoàn thành
            //threadB.Join(); // Đợi Process C hoàn thành
            /////-------------ABC--------
            //threadA.Start(); // Khởi động Process A
            //threadB.Start(); // Khởi động Process B
            //threadC.Start(); // Khởi động Process C

            //threadA.Join(); // Đợi Process A hoàn thành
            //threadB.Join(); // Đợi Process B hoàn thành
            //threadC.Join(); // Đợi Process C hoàn thành
            //---------------BAC-------------
            threadB.Start(); // Khởi động Process A
            threadA.Start(); // Khởi động Process B
            threadC.Start(); // Khởi động Process C

            threadB.Join(); // Đợi Process A hoàn thành
            threadA.Join(); // Đợi Process B hoàn thành
            threadC.Join(); // Đợi Process C hoàn thành
            // Hiển thị giá trị cuối cùng của a
            Console.WriteLine($"Final value of a: {a}");
            Console.ReadLine();
        }
        //-----------------ACB---------
        //static void ProcessA()
        //{
        //    semaphore1.WaitOne(); // Chỉ cho phép 1 process A
        //    a = a + 7; // Thao tác với a
        //    Console.WriteLine("Process A: " + a);
        //    semaphore2.Release(); // Giải phóng semaphore cho các process khác
        //}

        //static void ProcessB()
        //{
        //    semaphore3.WaitOne(); // Đợi Process A hoàn thành
        //    a = a - 5; // Thao tác với a
        //    Console.WriteLine("Process B: " + a);
        //}

        //static void ProcessC()
        //{

        //    semaphore1.Release(); // Giải phóng semaphore cho Process A
        //    semaphore2.WaitOne(); // Đợi Process B hoàn thành
        //    a = a * 3; // Thao tác với a
        //    Console.WriteLine("Process C: " + a);
        //    semaphore3.Release(); // Giải phóng semaphore cho Process A
        //}


        //-----------ABC---------------


        //static void ProcessA()
        //{
        //    semaphore1.WaitOne(); // Chỉ cho phép 1 process A
        //    a = a + 7; // Thao tác với a
        //    Console.WriteLine("Process A: " + a);
        //    semaphore2.Release();
        //    semaphore1.Release();// Giải phóng semaphore cho các process khác
        //}

        //static void ProcessB()
        //{
        //    semaphore1.WaitOne(); // Đợi Process A hoàn thành
        //    a = a - 5; // Thao tác với a
        //    Console.WriteLine("Process B: " + a);
        //    semaphore1.Release();
        //}

        //static void ProcessC()
        //{
        //    semaphore2.WaitOne(); // Đợi Process B hoàn thành
        //    a = a * 3; // Thao tác với a
        //    Console.WriteLine("Process C: " + a);
        //}
        //------------BAC---------------
        static void ProcessA()
        {
            semaphore1.WaitOne(); // Chỉ cho phép 1 process A
            a = a + 7; // Thao tác với a
            Console.WriteLine("Process A: " + a);
            semaphore2.Release();
            semaphore1.Release();// Giải phóng semaphore cho các process khác
        }

        static void ProcessB()
        {
            semaphore1.WaitOne(); // Đợi Process A hoàn thành
            a = a - 5; // Thao tác với a
            Console.WriteLine("Process B: " + a);
            semaphore1.Release();
        }

        static void ProcessC()
        {
            semaphore2.WaitOne(); // Đợi Process B hoàn thành
            a = a * 3; // Thao tác với a
            Console.WriteLine("Process C: " + a);
        }
    }
}