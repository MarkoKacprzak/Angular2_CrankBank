
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AccountSummary } from '../../shared/account-summary.type'

@Component({
    selector: 'account-summary',
    templateUrl: './account-summary.component.html',
    styleUrls: ['./account-summary.component.css']
})
export class AccountSummaryComponent {

    @Input() accountSummary: AccountSummary

    constructor(private router: Router) {
    }

    navigateToDetail() {
        //alert('detail');
        this.router.navigate(["detail", "12345"]);
    }
}
