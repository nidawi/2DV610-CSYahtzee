using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class CategoryScore
  {
    private ScoreCategory m_scoreCategory;

    public ScoreCategory Category => m_scoreCategory;

    public IReadOnlyList<int> FaceValues
    {
      get => throw new NotImplementedException();
      set
      {
        if (value.Count < 5 || value.Count > 6)
          throw new ArgumentOutOfRangeException();
      }
    }

    public int Score => throw new NotImplementedException();

    public CategoryScore(ScoreCategory a_scoreCategory)
    {
      m_scoreCategory = a_scoreCategory;
    }

    public void Set(int a_score, List<int> a_faceValues)
    {
      FaceValues = a_faceValues;
    }
  }
}
