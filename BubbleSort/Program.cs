using Utilities.Extensions;

namespace BubbleSort {
	internal class Program {
		static void Main(string[] args) {
			/*
			 * BUBBLE SORT
			 * 
			 * Bubble sort is a simple and elementary sorting algorithm that repeatedly 
			 * steps through the list to be sorted, compares adjacent elements, and swaps 
			 * them if they are in the wrong order. 
			 * 
			 * The algorithm gets its name from the way smaller elements "bubble" to the 
			 * top of the list while larger elements "sink" to the bottom during each pass.
			 * 
			 * Here's how the bubble sort algorithm works:
			 * 
			 * 1. Start with the first element (index 0) of the list.
			 * 2. Compare it with the next element (index 1). If the first element is greater 
			 * than the second element, swap them.
			 * 3. Move to the next pair of elements (index 1 and index 2) and repeat the 
			 * comparison and swap if necessary.
			 * 4. Continue this process, comparing and swapping adjacent elements throughout 
			 * the entire list.
			 * 5. After the first pass, the largest element will have "bubbled" to the end of 
			 * the list (position n-1).
			 * 6. Repeat the same process for the remaining n-1 elements (excluding the last 
			 * one that is already in its correct position).
			 * 7. Keep repeating the process until the list is fully sorted.
			 * 
			 * Bubble sort is straightforward to understand and implement, but it has some 
			 * significant limitations. Its average and worst-case time complexity is O(n^2), 
			 * where n is the number of elements in the list. This means that for large lists, 
			 * bubble sort can be very inefficient compared to more advanced sorting algorithms 
			 * like quicksort or merge sort, which have better time complexities. Nonetheless, 
			 * bubble sort is still useful for educational purposes and for sorting small lists 
			 * where its simplicity may outweigh its inefficiency.
			 * 
			 */

			int[] input = { 3, 7, 4, 8, 5, 2, 6, 8, 3, 1, 0 };
			Console.WriteLine($"Input: \t\t\t{input.ConvertToString()}");

			int[] ascending = BubbleSort(input);
			Console.WriteLine($"Sorted ascending: \t{ascending.ConvertToString()}");
		}

		private static int[] BubbleSort(int[] input) {
			// This algorithm iterates through all cells in the array, from back to front.
			for (int i = 0; i < input.Length; i++) {
				// Each iteration goes back only while j > i. That is because cells with
				// index j <= i are assumed to be already sorted.
				for (int j = input.Length - 1; j > i; j--) {
					// If the value in the current cell being compared is less than its
					// left neighbour, swap them.
					if (input[j] < input[j - 1]) { 
						int buffer = input[j];
						input[j] = input[j - 1];
						input[j - 1] = buffer;
					}
				}
			}

            return input;
		}
	}
}