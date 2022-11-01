export enum Operator {
    equals = 'eq',
    notEquals = 'neq',
    greaterThan = 'gt',
    greaterThanOrEquals = 'ge',
    lessThan = 'lt',
    lessThanOrEquals = 'lt',
    contains ='contains',
    startsWith = 'startsWith'
}

export class Filter {
    field: string;
    operator: Operator;
    value: any;

    constructor(field: string, value: any, operator?: Operator) {
        this.field = field;
        this.value = value;
        this.operator = operator || Operator.equals;
    }

    private getODataValue(): string {
        return typeof this.value === 'number' || typeof this.value === 'boolean'
            ? String(this.value)
            : '\'' + this.value + '\'';
    }

    toOData(): string {
        switch (this.operator) {
            case Operator.equals:
            case Operator.notEquals:
            case Operator.greaterThan:
            case Operator.greaterThanOrEquals:
            case Operator.lessThan:
            case Operator.lessThanOrEquals:
                return this.field + ' ' + this.operator + ' ' + this.getODataValue();
            case Operator.contains:
            case Operator.startsWith:
                return this.operator + '(' + this.field + ', ' + this.getODataValue() + ')';
        }
    }
}
