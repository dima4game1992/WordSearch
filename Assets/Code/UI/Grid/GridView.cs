using System.Collections.Generic;
using UnityEngine;

namespace WordSearch
{
    public class GridView : MonoBehaviour, IGrid
    {
        public void SetRows(IEnumerable<RowView> rows)
        {
            foreach (RowView row in rows) 
                row.transform.parent = transform;
        }
    }
}