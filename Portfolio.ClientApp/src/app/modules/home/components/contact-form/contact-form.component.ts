import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher, MatSnackBar } from '@angular/material';
import { ErrorSnackBarComponent, SuccessSnackBarComponent } from '@shared/components';
import { MainPageService } from '@core/services';
import { MailContact } from '@core/models';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss']
})
export class ContactFormComponent implements OnInit {

  requestProcessing: boolean;

  contactForm = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    subject: new FormControl('', Validators.required),
    details: new FormControl('', Validators.required)
  });

  matcher = new DefaultErrorStateMatcher();

  constructor(
    private matSnackBar: MatSnackBar,
    private mainPageService: MainPageService
    ) { }

  ngOnInit() {
  }

  onContactFormSubmit(): void {
    if(!this.contactForm.valid) {
      this.matSnackBar.openFromComponent(ErrorSnackBarComponent, {
        data: {
          message: "Contact form has errors. Please check your data and try again."
        },
        duration: 3000
      });
    } else {
      this.requestProcessing = true;
      this.mainPageService.sendContactingMail(this.contactForm.value as MailContact).toPromise()
      .then(() => {
        this.matSnackBar.openFromComponent(SuccessSnackBarComponent, {
          data: {
            message: "Message has been sent."
          },
          duration: 3000
        });
        this.contactForm.reset();
        this.contactForm.markAsUntouched();
        this.contactForm.updateValueAndValidity();
      })
      .catch((result: HttpErrorResponse) => {
        console.error(result);
        this.matSnackBar.openFromComponent(ErrorSnackBarComponent, {
          data: {
            message: "Server encountered an error. Please try again later."
          },
          duration: 3000
        });
      })
      .finally(() => {
        this.requestProcessing = false;
      });
    }
  }
}

export class DefaultErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.touched || isSubmitted));
  }
}
