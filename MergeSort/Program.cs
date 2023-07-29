using Utilities.Extensions;

namespace MergeSort
{
    internal class Program {
		static void Main(string[] args) {
			/*
			 * MERGE SORT
			 * 
			 * Merge sort is a popular sorting algorithm that follows the divide-and-conquer 
			 * paradigm. It breaks down the sorting process into smaller, more manageable 
			 * subproblems and then merges them back together to achieve the final sorted result. 
			 * 
			 * The basic steps of the merge sort algorithm are as follows:
			 * 
			 * - Divide: The unsorted list is divided into smaller sublists. This is done 
			 * recursively until the sublists contain only one element, as a single element is 
			 * inherently sorted.
			 * 
			 * - Conquer: The sublists are sorted individually. If a sublist has more than one 
			 * element, the sorting process will continue by dividing it into even smaller 
			 * sublists until the base case is reached (single-element sublists).
			 * 
			 * - Merge: The sorted sublists are merged back together to create larger sorted 
			 * sublists. This merging process continues until there is a single sorted list 
			 * containing all the elements from the original unsorted list.
			 * 
			 */

			int[] input = { 3, 7, 4, 8, 5, 2, 6, 8, 3, 1, 0 };
			Console.WriteLine($"Input: \t\t\t{input.ConvertToString()}");

			int[] ascending = MergeSort(input, 0, input.Length - 1);
			Console.WriteLine($"Sorted ascending: \t{ascending.ConvertToString()}");
		}

		private static int[] MergeSort(int[] array, int fromIndex, int toIndex) {
			// Checking the base case for this recursive method.
			// Sub-arrays of one single element are assumed to be an
			// ordered sub-array already, which current size is 1.
			// Hence returning the array.
			if (fromIndex >= toIndex)
				return array;

			// For sub-arrays with size > 1, the cell in the middle needs
			// to be identified, so as to further divide the sub-array.
			// Calculating middle cell index.
			int middleIndex = (fromIndex + toIndex) / 2;
			
			// Sorting each half.
			array = MergeSort(array, fromIndex, middleIndex);
			array = MergeSort(array, middleIndex + 1, toIndex);

			// The heart of this algorithm is in its merging sub-routine.
			// The goal of the merging algorithm is to compare the two arrays,
			// and one by one compare the values on each side. The lowest value of 
			// each comparison is stored in the array in the correct, ordered position.
			// This process continues until one of the sides runs out of values to compare.

			// Merging halves after both have been sorted.
			array = Merge(array, fromIndex, middleIndex, toIndex);

			// Returning result.
			return array;
		}

		private static int[] Merge(int[] array, int fromIndex, int middleIndex, int toIndex) {
			// The input array never really changes. The sub-arrays yielded from the
			// divide and conquer routine are managed by this method by creating physically
			// separate objects -- one for each half.

			// Calculating the size of each half.
			int sizeLeft = middleIndex - fromIndex + 1;
			int sizeRight = toIndex - middleIndex;

			// Moving each half to their own arrays.
			// Each array is created with one extra cell for the sentinel values, which
			// are explained later.
			int[] left = new int[sizeLeft + 1];
			int[] right = new int[sizeRight + 1];

			for (int i = 0; i < sizeLeft; i++) {
				left[i] = array[fromIndex + i];
			}

			for (int i = 0; i < sizeRight; i++) {
				right[i] = array[middleIndex + i + 1];
			}

			// Sentinels are a useful artifact to avoid having to check if the
			// end of one of the arrays have been reached. Instead, the last cell
			// is set to the maximum possible value. This guarantees that
			// the last value on the other half will be moved to the ordered sub-array.

			// Setting sentinels.
			left[sizeLeft] = int.MaxValue;
			right[sizeRight] = int.MaxValue;

			// With the setup complete, the algorithm compares the values on each half,
			// each time taking one from each side.
			// The lowest value between the two is put in the sorted position in the array. 

			int leftIndex = 0;
			int rightIndex = 0;

			for (int i = fromIndex; i <= toIndex; i++) {
				if (left[leftIndex] <= right[rightIndex]) {
					// If the value on the left is less than or equal to the one on the right,
					// it goes back into the array.
					array[i] = left[leftIndex];
					leftIndex++;
				}
				else {
					// If the value on the right is less than the one on the left,
					// then it goes back into the array first.
					array[i] = right[rightIndex];
					rightIndex++;
				}
			}

			return array;
		}
	}
}