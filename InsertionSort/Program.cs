using Utilities.Extensions;

namespace InsertionSort
{
    internal class Program {
		static void Main(string[] args) {
			/*
			 * INSERTION SORT
			 * 
			 * Insertion sort is a simple comparison-based 
			 * sorting algorithm that efficiently arranges 
			 * elements in ascending or descending order 
			 * within a list. 
			 * 
			 * It works by iteratively building a sorted 
			 * subarray at the beginning of the list. The 
			 * algorithm starts with the second element and 
			 * compares it with the elements to its left, 
			 * moving them one position to the right until 
			 * it finds the correct position for the current 
			 * element. This process continues until the entire 
			 * list is sorted. 
			 * 
			 * One easy way to think about this algorithm is
			 * comparing it to a shuffled deck of cards. As one
			 * takes the top card and places it on their left hand,
			 * new new card always goes in in sorted order. In this 
			 * analogy, the cards on the table are the input array, 
			 * and the cards on the left hand the sorted, output array.
			 * 
			 * Ultimately, the cards on hand still represent the set of
			 * cards originally in the input, but now in sorted order.
			 * 
			 * Despite its O(n^2) time complexity in the worst 
			 * case, insertion sort performs well on small 
			 * datasets and partially sorted arrays, making it 
			 * useful in certain scenarios where efficiency is 
			 * not a primary concern. 
			 * 
			 */

			int[] input = { 3, 7, 4, 8, 5, 2, 6, 8, 3, 1, 0 };
			Console.WriteLine($"Input: \t\t\t{input.ConvertToString()}");

			int[] ascending = SortAscending(input);
			Console.WriteLine($"Sorted ascending: \t{ascending.ConvertToString()}");

			int[] descending = SortDescending(input);
			Console.WriteLine($"Sorted descending: \t{descending.ConvertToString()}");
		}

		private static T[] SortAscending<T>(T[] array) where T : IComparable<T> {
			// The algorithm starts from the second value in the array.
			// That is because the first element is assumed to be in an
			// ordered sub-array already, which current size is 1.

			// The algorithm, then, iterates over the entire array,
			// starting from the second cell, and moving to the right.
			for (int i = 1; i < array.Length; i++) {
				// "current" is the value to move into the sorted sub-array.
				T current = array[i]; 
				int j = i - 1;

				// Comparing "current" with the values to the left in the array
				// until the correct position is found.
				while (j >= 0 && array[j].CompareTo(current) > 0) {
					// Shifting to the right every cell which value is greater than "current".
					array[j + 1] = array[j];

					// Decrementing j to check the next value to the left.
					j--;
				}

				// Leaving the loop means the position to insert "current" has been found.
				array[j + 1] = current;
			}

			return array;
		}

		private static T[] SortDescending<T>(T[] array) where T : IComparable<T> {
			for (int i = 1; i < array.Length; i++) {
				T current = array[i];
				int j = i - 1;

				// The only change to the algorithm is that now cells are shifted
				// when its value is less than "current".
				while (j >= 0 && array[j].CompareTo(current) < 0) {
					array[j + 1] = array[j];

					j--;
				}

				array[j + 1] = current;
			}

			return array;
		}
	}
}