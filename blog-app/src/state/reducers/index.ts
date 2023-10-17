import { combineReducers } from "redux";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { authorsReducer } from "./authorsReducer";
import { ThunkDispatch } from "redux-thunk";
import { AnyAction } from "redux";
import { blogReducer } from "./blogsReducer";
import { reducer as formReducer } from "redux-form";
import { tagsReducer } from "./tagsReducer";

export const reducers = combineReducers({
  authors: authorsReducer,
  blogs: blogReducer,
  tags: tagsReducer,
  form: formReducer,
});

export type AppState = ReturnType<typeof reducers>;
export type TypedDispatch<T> = ThunkDispatch<T, any, AnyAction>;
export const useAppDispatch = () => useDispatch<TypedDispatch<AppState>>();
export const useAppSelector: TypedUseSelectorHook<AppState> = useSelector;
