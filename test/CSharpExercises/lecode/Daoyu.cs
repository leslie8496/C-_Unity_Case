class Daoyu
{
    public void Run()
    {
    }

    //========二叉树===================
    /*给你二叉树的根节点 root ，返回其节点值的 层序遍历 。 （即逐层地，从左到右访问所有节点）。

       */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    //BFS方式解法
    /*
       输入：root = [3,9,20,null,null,15,7]
         输出：[[3],[9,20],[15,7]]
         示例 2：
         
         输入：root = [1]
         输出：[[1]]
         示例 3：
         
         输入：root = []
         输出：[]*/
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> treeData = new List<IList<int>>();
        if (root == null) return treeData;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            List<int> sonTreeData = new List<int>();
            int len = queue.Count;
            for (int i = 0; i < len; i++)
            {
                TreeNode curNode = queue.Dequeue();
                sonTreeData.Add(curNode.val);
                if (curNode.left!=null)
                {
                    queue.Enqueue(curNode.left);
                }

                if (curNode.right != null)
                {
                    queue.Enqueue(curNode.right);
                }
            }
            treeData.Add(sonTreeData);
        }
        
        return treeData;
    }

    //==============================岛屿
    /* 给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。

  岛屿总是被水包围，并且每座岛屿只能由水平方向和/或竖直方向上相邻的陆地连接形成。

  此外，你可以假设该网格的四条边均被水包围。 */
/*
输入：grid = [
  ['1','1','1','1','0'],
  ['1','1','0','1','0'],
  ['1','1','0','0','0'],
  ['0','0','0','0','0']
]
输出：1
 */
    //解法2 广度优先搜索 不用递归BFS
    public int NumIslands1(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        int landCount = 0;
        //提前定义四个方向的向量
        int[] dr = { 1, -1, 0, 0 };
        int[] dc = { 0, 0, 1, -1 };
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1')
                {
                    landCount++;
                    grid[r][c] = '2';
                    Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
                    queue.Enqueue((r, c));
                    while (queue.Count > 0)
                    {
                        (int curRow, int curCol) = queue.Dequeue(); //出列第一个
                        for (int i = 0; i < 4; i++)
                        {
                            int newRow = curRow + dr[i];
                            int newCol = curCol + dc[i];
                            if (newCol < 0 || newRow < 0 || newRow >= rows || newCol >= cols) continue;
                            if (grid[newRow][newCol] == '1')
                            {
                                grid[newRow][newCol] = '2';
                                queue.Enqueue((newRow, newCol));
                            }
                        }
                    }
                }
            }
        }

        return landCount;
    }


    //  解法1 深度优先搜索，需要用到递归
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0)
        {
            return 0;
        }

        int rows = grid.Length;
        int cols = grid[0].Length;
        int landCount = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1')
                {
                    landCount++;
                    //把所有东西都遍历掉
                    DFS_SinkIsLand(r, c, grid);
                }
            }
        }

        return landCount;
    }

    private void DFS_SinkIsLand(int r, int c, char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        if (r < 0 || r >= rows || c < 0 || c >= cols)
        {
            return;
        }

        if (grid[r][c] != '1')
        {
            return;
        }

        grid[r][c] = '2';
        DFS_SinkIsLand(r - 1, c, grid);
        DFS_SinkIsLand(r + 1, c, grid);
        DFS_SinkIsLand(r, c - 1, grid);
        DFS_SinkIsLand(r, c + 1, grid);
    }
}