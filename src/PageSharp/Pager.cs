
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageSharp{

    public class Pager<T> where T: class{
        public int TotalPages{get;private set;}
        public int PageSize{get;private set;}
        public Page<T> CurrentPage{get;private set;}
        public Page<T> PreviousPage{get;set;}
        public Page<T> NextPage{get;set;}
        public bool HasPages{get{ return _pagesStack.Count> 0;}}
        public int PagesRemaining{get{return _pagesStack.Count;}}
        public int PagesProcessed{get{return TotalPages - PagesRemaining;}}

        private Stack<Page<T>> _pagesStack = new Stack<Page<T>>();

        private Pager(int pageSize, IEnumerable<T> list)
        {
            PageSize = pageSize;

            BuildPages(list);

            if(_pagesStack.Count> 0)
                NextPage = _pagesStack.Peek();
        }
        public static Pager<T> Create(int pageSize, IEnumerable<T> collection){
            return new Pager<T>(pageSize, collection);
        }

        private void BuildPages(IEnumerable<T> items){
            if(items == null){
                TotalPages = 0;
                return;
            }
            TotalPages = GetTotalPageCount(items, PageSize);
            for(var i = 0; i < TotalPages; i++){
                _pagesStack.Push(new Page<T>{
                        Items = items.Skip(i * PageSize).Take(PageSize).ToList()
                });
            }

        }
        public Page<T> GetNextPage(){

            if(!HasPages){
                NextPage = null;
                return null;
            }

            PreviousPage = CurrentPage;
            CurrentPage = _pagesStack.Pop();
            Page<T> nextPage;
            var hasMorePages = _pagesStack.TryPeek(out nextPage);
            NextPage = hasMorePages ? nextPage : null;
            return CurrentPage;
        }

        private int GetTotalPageCount(IEnumerable<T> items, int pageSize){
            var count = items.Count();
            var hasPartialPage = count % pageSize != 0;
            var totalPages = (int)(Math.Round((double)count / (double)pageSize, 0));
            if(hasPartialPage){
                totalPages = totalPages +1;
            }
            return totalPages;
        }
    }


}