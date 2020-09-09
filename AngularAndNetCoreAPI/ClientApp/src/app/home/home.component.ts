import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'ap-home',
  templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit {
  public premium = 0;
  public quoteForm: FormGroup;
  private submitted = false;

  public occupationRatings: OccupationRatingModel[];

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseApiUrl: string,
    private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.quoteForm = this.formBuilder.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      dob: ['', Validators.required],
      occupationRating: ['', Validators.required],
      amount: ['', Validators.required],
    });

    this.getOccupationRatings();
  }

  get f() { return this.quoteForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.quoteForm.invalid) {
      return;
    }

    this.calcPremium();
  }

  onReset() {
    this.submitted = false;
    this.quoteForm.reset();
  }

  onOccupationChange(e) { this.onSubmit(); }

  onDobChange(e) {
    this.calcAge(e.target.value);
  }

  getOccupationRatings() {
    this.http.get<OccupationRatingModel[]>(this.baseApiUrl + 'premium').subscribe(result => {
      this.occupationRatings = result;
    }, error => console.error(error));
  }

  calcPremium() {
    let params = new HttpParams();
    params = params.append('amount', this.quoteForm.get('amount').value);
    params = params.append('occupationRating', this.quoteForm.get('occupationRating').value);
    params = params.append('age', this.quoteForm.get('age').value);
    params = params.append('dob', this.quoteForm.get('dob').value);

    this.http.get<number>(this.baseApiUrl + 'premium/quote', { params: params }).subscribe(result => {
      this.premium = result;
    }, error => console.error(error));
  }

  calcAge(dob) {
    

  }
}

interface OccupationRatingModel {
  occupation: string;
  rating: number;
}

interface PremiumQuoteModel {
  amount: number;
  occupationRating: number;
  age: number;
  dob: string;
}
