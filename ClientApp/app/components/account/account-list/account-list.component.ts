
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../shared/account.service';
import { AccountSummary } from '../../shared/account-summary.type'
import { AccountType } from '../../shared/account-type.enum'
    
@Component({
    selector: 'account-list',
    templateUrl: './account-list.component.html'
})
export class AccountListComponent {

    cashAccounts: AccountSummary[];
    creditAccounts: AccountSummary[];

    constructor(private accountService: AccountService) {
        
    }

    ngOnInit() {
        this.accountService.getAccountSummaries()
            .then(accounts => {
                this.cashAccounts = accounts.filter(v => v.type == AccountType.Checking || v.type == AccountType.Savings);
                this.creditAccounts = accounts.filter(v => v.type == AccountType.Credit);
            });
    }

}
