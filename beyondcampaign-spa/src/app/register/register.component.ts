import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FormBuilder, FormGroup, Validators, FormControl, } from '@angular/forms';
import { User } from '../_models/User';
import { fbind } from 'q';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;


  constructor(private authService: AuthService, private fb: FormBuilder ) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      userName: ['', Validators.required, this.userNameTakenValidator],
      email: ['', [Validators.email, Validators.required]],
      isGm: [''],
      isPlayer: [''],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }
  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  userNameTakenValidator(g: FormGroup) {
    if (this.authService.checkUsernameNotTaken) {
      return true;
    }
    return false;
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
