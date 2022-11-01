import { Address } from './address';

export interface Employee {
  id: number;
  surname: string;
  firstname: string;
  startDate: Date;
  position: string;
  positionLevel: string;
  annualGrossIncome: number;
  email: string;
  personalEmail: string;
  phone: string;
  personalPhone: string;
  birthDate: Date
  personalAddress: Address;
  address: Address;
  comments: string;
}