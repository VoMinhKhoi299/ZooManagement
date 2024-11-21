using System;
namespace CK.Functions
{
	public static class HealthQueue<T>
	{
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private static Node head = null;
        private static Node tail = null;
        private static int count = 0;

        // Thêm phần tử vào cuối hàng đợi
        public static void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        // Lấy phần tử từ đầu hàng đợi
        public static T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Hàng đợi trống.");
            }

            var result = head.Data;
            head = head.Next;

            if (head == null)
            {
                tail = null;
            }

            count--;
            return result;
        }

        // Xem phần tử đầu hàng đợi mà không xóa
        public static T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Hàng đợi trống.");
            }

            return head.Data;
        }

        // Kiểm tra hàng đợi có rỗng không
        public static bool IsEmpty()
        {
            return head == null;
        }

        // Đếm số phần tử trong hàng đợi
        public static int Count()
        {
            return count;
        }

        // Xóa toàn bộ hàng đợi
        public static void Clear()
        {
            head = tail = null;
            count = 0;
        }
    }
}


