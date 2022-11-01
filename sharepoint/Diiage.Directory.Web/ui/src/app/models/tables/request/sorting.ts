export class Sorting {
    field: string;
    isAscending: boolean;

    constructor(field: string, isAscending?: boolean) {
        this.field = field;
        this.isAscending = isAscending || true;
    }

    toOData(): string {
        return this.field + ' ' + (this.isAscending ? 'asc' : 'desc');
    }
}
