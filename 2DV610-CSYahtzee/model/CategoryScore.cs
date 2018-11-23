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
    private int? m_score;

    public ScoreCategory Category => m_scoreCategory;

    public IReadOnlyList<int> FaceValues
    {
      get => throw new NotImplementedException();
      private set
      {
        if (value.Count < 5 || value.Count > 6)
          throw new ArgumentOutOfRangeException();
        else if (value.Any(x => x < 1 || x > 6))
          throw new InvalidDieException();
      }
    }
    
    public int Score
    {
      get => m_score.HasValue ? m_score.Value : throw new NotImplementedException();
      private set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException();

        m_score = value;
      }
    }

    public CategoryScore(ScoreCategory a_scoreCategory)
    {
      m_scoreCategory = a_scoreCategory;
      m_score = null;
    }

    public void Set(int a_score, List<int> a_faceValues)
    {
      Score = a_score;
      FaceValues = a_faceValues;
    }
  }
}
