import { Sorting } from './sorting';
import { Filter } from './filter';

export class Query {
    pageIndex = 0;
    pageSize = 15;
    sorts: Array<Sorting> = [];
    filters: Array<Filter> = [];

    toOData(): string {
        return '$skip=' + (this.pageIndex * this.pageSize)
            + '&$top=' + this.pageSize
            + (this.filters.length
                ? this.filters.reduce((prev, current, index, array) => {
                return prev + (index ? ' and ' : '') + current.toOData();
                }, '&$filter=')
                : '')
            + (this.sorts.length
                ? this.sorts.reduce((prev, current, index, array) => {
                    return prev + (index ? ',' : '') + current.toOData();
                }, '&$orderby=')
                : '');
    }
}
