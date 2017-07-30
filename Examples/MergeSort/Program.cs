using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort{

    public class MergeSort
    {
        public int[] a;
        public MergeSort(int[] a)
        {
            this.a = a;        
        }

        public void merge(int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];
            for (int k = 0; k < n1; k++)
            {
                L[k] = a[p + k];

            }
            for (int m = 0; m < n2; m++)
            {

                R[m] = a[q + m + 1];
            }
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;
            int i = 0;
            int j = 0;
            for (int k = p; k <= r; k++)
            {
                if (L[i] < R[j])
                {
                    a[k] = L[i];
                    i = i + 1;
                }
                else
                {
                    a[k] = R[j];
                    j = j + 1;
                }
            }
        }

        public void mergeSortPass(int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                mergeSortPass(p, q);
                mergeSortPass(q + 1, r);
                merge(p, q, r);
            }
        }
       public void mergeSort() 
        {
        mergeSortPass(0, a.Length - 1);
        }
                      
    }
                    
    class Program
    {            
        static void Main(string[] args)
        {
            var merge = new MergeSort(new int[] {4, 8, 5, 7, 4, 9, 3, 2, 1 ,10,22,78,17,201, 78,2,10,24,27});
            merge.mergeSort();

            foreach(var i in merge.a)
            Console.WriteLine(i);
           
        }


    }

    
    
}
