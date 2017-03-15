
import { Component } from '@angular/core';
import { AccountSummary } from '../../shared/account-summary.type'
import { AccountType } from '../../shared/account-type.enum'
    
@Component({
    selector: 'account-list',
    templateUrl: './account-list.component.html'
})
export class AccountListComponent {

    cashAccounts: AccountSummary[];
    creditAccounts: AccountSummary[];

    constructor() {
        this.cashAccounts = [
            { accountNumber: "123-234-4567", balance: 1234.56, name: "MyChecking", type: AccountType.Checking },
            { accountNumber: "234-456-3224", balance: 4562.14, name: "MySavings", type: AccountType.Savings }
        ];

        this.creditAccounts = [
            { accountNumber: "1113-2222-4444", balance: 652.02, name: "MyCreditCard", type: AccountType.Credit }
        ];
    }
}
