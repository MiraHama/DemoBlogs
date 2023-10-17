import React from "react";
import Header from "./Header";
import "./Layout.css";
import Footer from "./Footer";

type Props = {
  children?: React.ReactNode;
};

const Layout: React.FC<Props> = ({ children }: Props) => {
  return (
    <div className="container">
      <Header />
      <main>{children}</main>
      <Footer />
    </div>
  );
};

export default Layout;
