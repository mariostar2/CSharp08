using System;

namespace CSharp08
{

    class Shop
    {
        const int MAX_NONEY = 10000;
        public readonly int MAX_GUEST;          //생성자 내부에 한해 값을 변경할 수 있다.
        public Shop(int maxGuest)
        {
            MAX_GUEST = maxGuest;
        }
    }

    internal class Program
    {

        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SwapRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        //out: ref와 비슷하게 참조 형태로 변수를 전달한다.
        // 단, 함수가 종료된 후에 어떠한 값이라도 대입됨을 보장한다.
        static void Get(out int num)
        {
            num = 100;
        }

        static void GefRef(ref int num)
        {
            // 비어있음
        }

        #region params키워드
        // params : 이후에 오는 모든 값들을 묶어준다
        static void PrintArray(string str, params int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"{i} : {array[i]}");
        }

        class MyException : Exception
        {

        }



        //열거형 
        //=상수의 나열
        const int WEEK_SUN = 0;
        const int WEEK_MON = 1;
        const int WEEK_TUS = 2;
        const int WEEK_WED = 3;
        const int WEEK_THU = 4;
        const int WEEK_FRI = 5;
        const int WEEK_SAT = 6;
        [Flags]

        enum WEEK
        {
            // << 쉬프트 연산자
            Sunday = 1 << 0,  //1을 좌측으로 0번 쉬프트 하라
            Monday = 1 << 1,
            Tuesday = 1 << 2,
            Wednesday = 1 << 3,
            Thursday = 1 << 4,
            Friday = 1 << 5,
            Saturday = 1 << 6,
        }


        static void Main(string[] args)
        {
            if (false)
            {
                //예외 try -catch
                int[] a = { 1, 2, 3 };
                int number = 0;

                try
                {
                    Console.Write("값을 가져올 베열 index :");
                    int input = int.Parse(Console.ReadLine());
                    number = a[input];
                    //Console.WriteLine("입력종료");        //try도중에 에러가 발생하면 해당 줄은 실행되지 못한다.
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    number = 0;
                }

                finally
                {
                    //try가 성공적으로 종료가 되어도 ,예외로 catch문이 실행되어도 
                    //최종적으로 불리는 영역.
                    Console.WriteLine("입력종료");
                }
                int i = 0;
                for (i = 0; i < 10; i++)
                {

                }
                Console.WriteLine($"i: {i}");
                Console.WriteLine($"number{number}");
            }
            #region out과 ref
            int n1 = 100;
            int n2 = 200;

            Swap(n1, n2);
            Console.WriteLine($"Swap n1:{n1}, n2:{n2}");

            SwapRef(ref n1, ref n2);
            Console.WriteLine($"Ref n1:{n1}, n2:{n2}");
            #endregion
            if (false)

            {
                //printArray는 1개의 매개변수를 받지만 params키워드를 사용했기 때문에
                //제한없이 int값을 받아올 수 있다
                PrintArray("A", 10, 20, 30, 40, 50, 60);   //(string,int,int,int,int,int)
                PrintArray("B", 10, 20, 30);                //(string, int, int, int)
                PrintArray("C", 10);                         //(string, int)
                #endregion

                //상수 :변하지 않는수 (이름규칙: 상수는 모든 대문자 공백은 언더바(__)로 구분
                const int MAX_NUM = 100;

                Shop shop1 = new Shop(10);
                Shop shop2 = new Shop(30);

                Console.WriteLine($"shop1은 최대 {shop1.MAX_GUEST}의 인원까지 받을 수 있다");
                Console.WriteLine($"shop2은 최대 {shop2.MAX_GUEST}의 인원까지 받을 수 있다");
            }

            //0:월 ~6: 토
            int week = WEEK_WED;
            WEEK oneWeek = WEEK.Tuesday;
            if (oneWeek == WEEK.Tuesday) ;
            Console.WriteLine("목요일이 맞다");

            //A AND B(=교집합) : 둘다 1일 경우 1이다.
            Console.WriteLine($"1 & 1 :{1 & 1} ");
            Console.WriteLine($"1 & 0 :{1 & 0} ");
            Console.WriteLine($"0 & 1 :{0 & 1} ");
            Console.WriteLine($"0 & 0 :{0 & 0} ");

            // A|B(=합집합, OR연산) : 둘중 하나라도 1이면 1이다
            Console.WriteLine($"1 | 1 :{1 | 1} ");
            Console.WriteLine($"1 | 0 :{1 | 0} ");
            Console.WriteLine($"0 | 1 :{0 | 1} ");
            Console.WriteLine($"0 | 0 :{0 | 0} ");

            Student student = new Student("학생", WEEK.Sunday, WEEK.Monday, WEEK.Thursday);
            Console.WriteLine($"{student.name}은 월요일에 학원을 가나요?:{student.IsWeek(WEEK.Monday)}");

        }
        class Student
        {
            public string name;
            public WEEK classWeek; //수업에 나가는 요일
            public Student(string name, params WEEK[] weeks)
            {
                this.name = name;
                foreach (WEEK week in weeks)
                    classWeek |= week;
                // a+ b a와b를 더하라 (a의 값은 변한다? X)
                // a += b a 와 b를 더한값을 a에 대입한다 (a의 값은 변한다?  정답: A의 값이 변한다)

            }
            public bool IsWeek(WEEK week)
            {
                //학생의 학원가는날에 원하는 요일을 and연산 시켜
                //0이 아닌 값이 나올 경우 포함하고 있다고 본다.
                return (classWeek & week) != 0;
            }
        }


        //아래의 경우 결과 값 만을 반환할 수 있기 때문에
        //제데로 계산이 되었는지의 여부는 알 수 없다.
        static int Divide(int divisor, int divide)
        {
            //나누는 값이 0일 경우
            if (divide == 0)
            {
                return 0;
            }
            return divisor / divide;
        }
        //아래의 경우에는 반환값을로 실행 결과를 리턴하고
        //out 키워드로 계산된 결과값을 전달하고 있다.
        static bool Divide2(int divisor, int divide, out int result)
        {
            if (divide == 0)
            {
                result = 0;
                return false;
            }
            result = divisor / divide;
            return true;
        }

        static void Give(int num)
        {
            num = 100;
        }

        //함수가 종료 되어 있을때 매개 변수에 값이 대입됨을 보장하는 키워드.
        // 실제 변수의 주소가 참조된다.
        static void Give(out int num)
        {
            num = 100;
        }




    }

}

