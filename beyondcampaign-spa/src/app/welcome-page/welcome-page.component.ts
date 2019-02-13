import { Component, OnInit } from '@angular/core';
import { registerModuleFactory } from '@angular/core/src/linker/ng_module_factory_loader';

@Component({
  selector: 'app-welcome-page',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css']
})
export class WelcomePageComponent implements OnInit {
  registerMode = false;

  constructor() { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
