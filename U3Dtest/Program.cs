using System;
namespace U3Dtest
{
    /*
     * 1、休闲游戏排行榜
     */
    public class LeaderboardSystem
    {
        /*
         * 普通的筛选使用系统自带的排序库，在找到最大的m个数即可
         * 时间复杂度为O(n logn),n为数组大小
         */
        public static List<int> GetTopScores(int[] scores, int m)
        {
            // 如果数组为空或 m 小于等于 0，返回空列表
            if (scores == null || scores.Length == 0 || m <= 0)
            {
                return new List<int>();
            }

            // 对 scores 数组进行排序，按从大到小的顺序
            Array.Sort(scores);
            Array.Reverse(scores);

            // 获取前 m 个分数，如果 m 大于数组长度，取整个数组
            m = Math.Min(m, scores.Length);
            List<int> topScores = new List<int>();

            for (int i = 0; i < m; i++)
            {
                topScores.Add(scores[i]);
            }

            return topScores;
            // 在这⾥实现你的代码
        }

        /*
         * 进阶：
         * 发现只需要对前m个最高分进行排序，不必对整个数组进行完全排序。
         * 可以使用最小堆来追踪前 m 个分数。
         * 最小堆的特点是堆顶元素始终是堆中最小的值，因此只要堆的大小超过 m，就可以将堆顶元素弹出。
         * 此时遍历整个数组时间复杂度是O(n)，插入堆是O(log m)，整体是O(nlogm)
         * 一般来说，游戏中，显示的排名数m值都是较小的，当n值较大而m较小时此算法更加高效。
         */
        public static List<int> GetTopScoresPro(int[] scores, int m)
        {
            if (scores == null || scores.Length == 0 || m <= 0)
            {
                return new List<int>();
            }

            // 最小堆，使用优先队列 PriorityQueue
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            foreach (int score in scores)
            {
                // 添加到堆中
                minHeap.Enqueue(score, score);

                // 保持堆的大小为 m
                if (minHeap.Count > m)
                {
                    minHeap.Dequeue();
                }
            }

            // 取出堆中的所有元素，并逆序排列
            List<int> topScores = new List<int>();
            while (minHeap.Count > 0)
            {
                topScores.Add(minHeap.Dequeue());
            }

            topScores.Reverse();  // 由于堆是最小堆，需要反转成从高到低
            return topScores;
        }


        static void Main(string[] args)
        {
            int[] scores = { 100, 200, 150, 180, 250 };
            List<int> result = GetTopScoresPro(scores, 3);

            foreach(int i in result)
            {
                Console.WriteLine(i);
            }

        }
    }


    /*
     * 2、魔法能量场
     */
    public class EnergyFieldSystem
    {

        /*
         * 考虑到游戏中数据量不可能很大，采用双循环，时间复杂度是O(n2)
         */
        public static float MaxEnergyField(int[] heights)
        {
            float res = 0;

            for(int i = 1; i < heights.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    float ans = (float)(heights[i] + heights[j]) * (float)(i - j) / 2;
                    res = Math.Max(ans, res);
                }
            }
            return res;
        }

        /*
         * 进阶1：
         *     将上述每个heights[i]临时增加高度，在进行计算即可。
         *     
         * 进阶2：
         *     倘若高度为0时仍然能够计算能量则无影响；若不能则只需要在计算时添加对于0的判断即可。
         *     
         * 创意思考：
         *     由于是根据梯形面积来判断能量场的强度，玩家在建造时通常会考虑两端或者可建高度更高的
         *  能量塔进行建造。游戏玩法思考：（游戏奖励模式）在有限的时间内，玩家需要建造两个能量塔，
         *  完成后，玩家可以得到建造能量塔构成的能量场范围内的奖励
         */
    }


    /*
     * 3、魔法宝箱探险
     */
    public class TreasureHuntSystem
    {
        /*
         * 经典动规问题，dp[i,0]表示前i个宝箱能够开出的最大价值，0表示不选第i个宝箱，1表示选
         * 算法时间复杂度为O(n)，空间为O(n);
         */
        public static int MaxTreasureValue(int[] treasures)
        {
            if (treasures.Length == 0) return 0;
            // 在这⾥实现你的代码
            int[,] dp = new int[treasures.Length, 2];

            dp[0, 0] = 0;
            dp[0, 1] = treasures[0];
            for (int i = 1; i < treasures.Length; i++)
            {

                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = dp[i - 1, 0] + treasures[i];
            }

            return Math.Max(dp[treasures.Length - 1, 0], dp[treasures.Length-1,1]);
        }

        /*
         * 进阶1：
         *     想法是再增加一维，0表示前i个宝箱还未使用魔法钥匙的情况，1表示已使用过。
         *     状态转移方程为：
         *       dp[i,0,0]=Math.Max(dp[i-1,0,0],dp[i-1,1,0]);
         *       dp[i,1,0]=dp[i-1,0,0]+treasures[i];
         *       dp[i,0,1]=Math.Max(dp[i-1,0,1],dp[i-1,1,1]);
         *       dp[i,1,1]=Math.Max(dp[i-1,0,1]+treasures[i],dp[i-1,1,0]+treasures[i]);
         *     此时由于仅仅增加了数量为2的一维，时间复杂度和空间复杂度均不变。
         * 进阶2：
         *     上述动态规划中，由于总是考虑选和不选的情况，因此负值不会影响上述算法的最终结果
         * 创意思考：
         *     有趣的策略选择：1、玩家需要评估每个宝箱的价值与相邻宝箱的风险；2、玩家在游戏过程中会根
         *     据已打开宝箱的价值动态调整策略；3、设计多个玩家或NPC角色，每个角色都有不同的选择策略。
         *     玩家可以通过观察其他角色的行为来推测他们的策略，从而做出更优选择等等。
         *     
         *     关卡设计：在经典的RPG游戏中，玩家每过一关可以选择强化自己的武器或属性，根据不同的选择
         *     成为不同的流派，最终打boss。
         *                     
         */
    }

    /*
     * 4、魔法天赋评估系统
     */
    public class TalentAssessmentSystem
    {

        /*
         * 典型的归并排序问题，时间复杂度为O(n+m),空间为O(n+m);
         */
        public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
        {
            int[] ans = new int[fireAbility.Length + iceAbility.Length];

            
            int fireLen = fireAbility.Length, iceLen = iceAbility.Length;

            if (fireLen == 0 && iceLen == 0) return 0;
            int i = 0, j = 0, k = 0;
            while (i < fireLen && j < iceLen)
            {
                
                while (i < fireLen && fireAbility[i] <= iceAbility[j])
                {
                    ans[k] = fireAbility[i];
                    i++;
                    k++;
                }
                if (i >= fireLen)
                {
                    break;
                }
                while (j < iceLen && iceAbility[j] <= fireAbility[i])
                {
                    ans[k] = iceAbility[j];
                    j++;
                    k++;
                }
            }
            while (i < fireLen)
            {
                ans[k] = fireAbility[i];
                i++;
                k++;
            }
            while (j < iceLen)
            {
                ans[k] = iceAbility[j];
                j++;
                k++;
            }

            if (k % 2 == 0)
            {

                return ((double)ans[k / 2 - 1] + (double)ans[k / 2]) / 2;
            }
            else
            {
                return (double)ans[k / 2 ];
            }
        }


        /*
         * 进阶1：算法优化：本质只需要求出中位数即可，不需要进行完整的排序。上述归并算法中，根据两个
         *        数组的大小相加可知道合并后的数组大小，即可知中位数在合并数组的索引，当k的值达到中位数
         *        的索引后，直接返回即可，此后的归并不需进行。空间优化：同理，只需要找到中位数即可，无
         *        需开辟新的数组存储合并后的。
         * 进阶2：为每个数组创建一个结构体，结构体包括当前元素的下标以及该数组的首地址。与上述归并排序
         *        同理，每次找到所有数组中当前索引下最小元素的数组，使其当前索引加一，由于数组个数不变，
         *        可采用最小堆每次找出最小元素的数组。
         * 创意思考：
         *        1、魔法专精：天赋指数高的魔法属性可以决定角色的魔法专精。例如，如果角色的火元素
         *        天赋值高，他们会更容易掌握与火相关的魔法技能。这让玩家根据自己的天赋在火焰、冰霜、风暴等
         *        魔法流派中做出选择。
         *        2、技能树解锁：
         *        玩家根据天赋指数解锁不同的技能树。高天赋值会解锁更强大和稀有的魔法技能，而低天赋值的属性
         *        可能会限制某些技能的学习或使用效率。这样，角色在不同的魔法属性上有不同的成长路径。
         *        3、技能学习的速度与成本：
         *        根据天赋值，学习特定技能的速度或学习所需资源（如经验值、金币等）可以有所不同。高天
         *        赋值意味着学习相关技能更快、消耗更少，而低天赋值则意味着技能学习成本更高。
         *        4、专属任务：
         *        根据学徒的天赋，系统可以生成与其属性相关的专属任务。例如，火元素天赋高的角色可以
         *        接受以火焰为主的战斗任务，或者需要解决火系魔法难题的任务，而冰元素天赋高的角色则
         *        可能获得与寒冰相关的探索任务。
         *        5、PVP对战：
         *        可增加属性相克相生的机制，如风助火势，风属性技能与火属性技能会叠加效果；水克火等等。
         *        
         */

    }


}