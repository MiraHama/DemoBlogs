import { Field, reduxForm, InjectedFormProps } from "redux-form";
import { AppState, TypedDispatch, postBlogs } from "../state";
import { HTMLAttributes } from "react";
import { useNavigate } from "react-router-dom";

interface Values {
  title: string;
  textBody: string;
  authorName: string;
  tags?: string;
}

const validate = (values: Values) => {
  const errors = { title: "", textBody: "", authorName: "", tags: "" };
  if (!values.title) {
    errors.title = "Blog Title is Required";
  } else if (values.title.length > 50) {
    errors.title = "Must be 50 characters or less";
  }
  if (!values.textBody) {
    errors.textBody = "Blog Text is Required";
  }
  if (!values.authorName) {
    errors.authorName = "Author Name is Required";
  } else if (values.authorName.length > 50) {
    errors.title = "Must be 50 characters or less";
  }
  if (values.tags) {
    const tags = values.tags?.split(",");
    tags.map((t) =>
      t.length > 20 ? (errors.tags = "Tag must be 20 characters or less") : null
    );
  }
  return errors;
};

interface FieldProps {
  input: HTMLAttributes<HTMLInputElement>;
  label: string;
  type: string;
  placeholder: string;
  meta: {
    touched: boolean;
    error: string;
  };
}

const renderField: React.FC<FieldProps> = ({
  input,
  label,
  type,
  placeholder,
  meta: { touched, error },
}) => (
  <div>
    <label>{label}</label>
    <div>
      <input {...input} placeholder={placeholder} type={type} />
      {touched && error && <span>{error}</span>}
    </div>
  </div>
);

const BlogForm = (props: InjectedFormProps<Values>) => {
  const { handleSubmit, pristine, reset, submitting } = props;
  const navigate = useNavigate();

  const onSubmit = async (values: any, dispatch: TypedDispatch<AppState>) => {
    const tags = values.tags?.split(",");
    const sendValues = { ...values, tags: tags ? tags : undefined };
    await dispatch(postBlogs(sendValues));
    navigate("/");
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div>
        <label>Blog Title</label>
        <div>
          <Field
            name="title"
            component={renderField}
            type="text"
            placeholder="Title"
          />
        </div>
      </div>
      <div>
        <label>Blog Text</label>
        <div>
          <Field
            name="textBody"
            component={renderField}
            type="textarea"
            placeholder="Text"
          />
        </div>
      </div>
      <div>
        <label>Blog Author</label>
        <div>
          <Field
            name="authorName"
            component={renderField}
            type="text"
            placeholder="Author"
          />
        </div>
      </div>
      <div>
        <label>Blog Tags</label>
        <div>
          <Field
            name="tags"
            component={renderField}
            type="textarea"
            placeholder="Separate by comma"
          />
        </div>
      </div>
      <div>
        <button type="submit" disabled={pristine || submitting}>
          Submit
        </button>
        <button type="button" disabled={pristine || submitting} onClick={reset}>
          Clear Values
        </button>
      </div>
    </form>
  );
};

export default reduxForm({
  form: "blog",
  validate,
})(BlogForm);
