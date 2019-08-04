import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatChipsModule, MatSnackBarModule, MatSnackBar } from '@angular/material';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorSnackBarComponent } from './components/error-snack-bar/error-snack-bar.component';

@NgModule({
  declarations: [ErrorSnackBarComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatChipsModule,
    MatSnackBarModule,
    ReactiveFormsModule
  ],
  exports: [
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatChipsModule,
    MatSnackBarModule,
    ReactiveFormsModule
  ],
  providers: [
    MatSnackBar
  ]
})
export class SharedModule { }