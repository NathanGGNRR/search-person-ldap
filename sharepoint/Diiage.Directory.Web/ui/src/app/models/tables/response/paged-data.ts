export class PagedData<T> {
    data = new Array<T>();
    itemsCount = 0;

    constructor(data: Array<T>, itemsCount: number) {
        this.data = data;
        this.itemsCount = itemsCount;
    }
}
