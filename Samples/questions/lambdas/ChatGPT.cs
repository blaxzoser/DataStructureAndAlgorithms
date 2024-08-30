using Samples.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.questions.lambdas
{
    public class ChatGPT
    {
        /// <summary>
        /// Exercise 1: Basic Lambda Expression
        /// Task: Create a lambda expression that takes two integers as input and returns their sum.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SumLambda(int a, int b)
        {
            //int[] sum = new[] { a, b };
            //return sum.Sum();

            //another solution
            // Lambda expression to sum two integers
            Func<int, int, int> sum2 = (c, d) => c + d;
            return sum2(a,b);
        }

        /// <summary>
        /// Exercise 2: Lambda with List Filtering
        /// Task: Use a lambda expression to filter a list of integers.
        /// Use the Where method with a lambda expression to filter out only the even numbers.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<int> FilterLambda(List<int> source){
            return source.Where(s => s % 2 == 0).ToList();
        }

        /// <summary>
        /// Exercise 3: Lambda for Sorting
        /// Task: Use a lambda expression to sort a list of strings by their length.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<string> OrderLambda(List<string> source)
        {
            return source.OrderBy(s => s.Length).ToList();
        }

        /// <summary>
        /// Exercise 4: Lambda as a Parameter
        ///Task: Write a method that takes a lambda expression as a parameter.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public void  PerformOperation(Action<int> action, int parameter)
        {
            action(parameter);         
        }

        /// <summary>
        /// Exercise 5: Lambda for Transforming a List
        /// Task: Use a lambda expression to transform each element in a list.
        /// Use the Select method with a lambda expression to create a new list where each number is squared.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<int> TransformLambda(List<int> source)
        {
            return source.Select(s => s*s).ToList();
        }

        //Exercise 6: Combining Lambdas and Anonymous Methods
        //Task: Use both a lambda expression and an anonymous method in a list operation.
        //Use an anonymous method with the FindAll method to find all numbers greater than 2.
        public List<int> TransformCombinationLambda(List<int> source)
        {
            //return source.FindAll(s => s > 2).ToList();
            
            //another solution 
            return source.FindAll(delegate (int n) { return n > 2; });

        }

        //Exercise 7: Lambda with Custom Objects
        //Task: Use a lambda expression to filter and sort a custom object list.
        //Create a Person class with properties Name and Age.
        //Create a list of Person objects.
        //Use the Where method with a lambda to filter out people older than 30.
        //Use the OrderBy method with a lambda to sort the remaining people by their name.
        //Print the filtered and sorted list.
        public List<Person> GetPersonsOrderByName(List<Person> people)
        {
            var debug = people.Where(s => s.Age > 30)
                .OrderBy(x => x.Name);

            return debug.ToList<Person>();
        }

        //169. Majority Element by Alberto
        //Count the majority and return the max
        // Sample:
        // { 1,1,2}
        // return  2
        // Sample 2:
        //{4,5,6,5,4,4}
        //return 3
        public int MajorityElement(int[] numers)
        {
            return numers.GroupBy(x => x).Select(
                    g => new { key = g, count = g.Count() }
                ).OrderByDescending(g => g.count).FirstOrDefault().count;
        
        }

    }
}
