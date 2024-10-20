using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DSPractice
{
    internal class new2024Ques
    {
        public (int[], int) RemoveDuplicates1(int[] nums)
        {
            int cnt = 1, appear = 1;
            for(int i= 1; i< nums.Length; i++)
            {
                if (nums[i] == nums[i-1])
                {
                    if (appear == 1)
                    {
                        nums[cnt] = nums[i];
                        cnt++;
                        appear++;
                    }
                    else if (appear == 2) continue;
                }
                else
                {
                    nums[cnt] = nums[i];
                    cnt++;
                    appear = 1;   
                }
            }
            return (nums, cnt);

        }

        public (int[],int) RemoveDuplicates2(int[] nums)
        {
            int next = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(i == 0 || i == 1) nums[next++] = nums[i];
                else if (nums[i] != nums[i-1] || nums[i] != nums[i-2])
                {
                    nums[next++] = nums[i];
                }
            }
            return (nums,next);
        }
    }
}
