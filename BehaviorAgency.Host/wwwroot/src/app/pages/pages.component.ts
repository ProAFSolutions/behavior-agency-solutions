import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { AgencyMenuItems, RBTMenuItems } from './pages.menu';


@Component({
  selector: 'behavior-app-pages',
  template: `
    <ngx-one-column-layout>
      <nb-menu [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class PagesComponent implements OnInit{

  public menu: NbMenuItem[];


  ngOnInit(): void {
     this.menu = AgencyMenuItems;
     //this.menu = RBTMenuItems;
  }
  
}
